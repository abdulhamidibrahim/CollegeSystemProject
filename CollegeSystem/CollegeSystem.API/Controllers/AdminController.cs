using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CollegeSystem.BL.DTOs;
using CollegeSystem.BL.DTOs.User;
using CollegeSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using User.Management.Services.Models;
using IEmailService = User.Management.Services.Services.IEmailService;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _config;

    public AdminController(UserManager<ApplicationUser> userManager, IEmailService emailService, IConfiguration config)
    {
        _userManager = userManager;
        _emailService = emailService;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(AdminRegisterDto adminRegisterDto)
    {
        if (ModelState.IsValid)
        {
            Admin user = new Admin
            {
                UserName = adminRegisterDto.UserName,
                Email = adminRegisterDto.Email,
                Name = adminRegisterDto.Name,
                Phone = adminRegisterDto.Phone,
                EmailConfirmed = false,
                TwoFactorEnabled = true
            };

            IdentityResult result = await _userManager.CreateAsync(user, adminRegisterDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, adminRegisterDto.Role);
            // send email verification to the user
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Admin", new { token, email = user.Email },
                Request.Scheme);
            var message = new Message(new[] { user.Email }, "Confirmation email link", confirmationLink!);

            _emailService.SendEmail(message);
            return Ok(
                "Account created successfully, we have sent a confirmation email, please click the link to confirm your email");
        }

        var errors = ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
        return BadRequest(errors);
    }


    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(AdminLoginDto adminLoginDto)
    {
        if (ModelState.IsValid)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(adminLoginDto.UserName);
            if (user != null)
            {
                bool found = await _userManager.CheckPasswordAsync(user, adminLoginDto.Password);
                if (found)
                {
                    // create tokens 

                    var claims = new List<Claim>
                    {
                        // Debug.Assert(user.UserName != null, "user.UserName != null");
                        new Claim(ClaimTypes.Name, user.UserName!),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var itemRole in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, itemRole));

                    }

                    SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:secret"]!));
                    SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken myToken = new JwtSecurityToken(
                        issuer: _config["JWT:issuer"], // provider
                        audience: _config["JWT:audience"], // consumer 
                        claims: claims,
                        expires: DateTime.Now.AddHours(5),
                        signingCredentials: credentials
                    );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(myToken),
                        expiration = myToken.ValidTo
                    });
                }
            }

            return Unauthorized();
        }

        return Unauthorized();
    }


    [HttpGet]
    [Route("confirmEmail")]
    public async Task<ActionResult> ConfirmEmail(string token, string email)
    {
        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
        {
            return NotFound("Invalid token or Email");
        }

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return NotFound("User not found");

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return BadRequest("Invalid token");
        }

        return Ok("Email confirmed successfully");
    }
    
    [HttpPost("forgotPassword")]
    public async Task<ActionResult> ForgotPassword(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return BadRequest("User not found");
        var token = await _userManager.GenerateUserTokenAsync(user, "Email","ResetFactor");
        var passwordResetLink = Url.Action(nameof(ResetPassword), "Admin", new { token, email = user.Email },Request.Scheme);
        var message = new Message(new[] { user.Email }!, "Reset password link", passwordResetLink!);
        _emailService.SendEmail(message);
        return Ok("Password reset link sent successfully");
    }
    
    [HttpGet("resetPassword")]
    public ActionResult ResetPassword(string token, string email)
    {
        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
        {
            return NotFound("Invalid token or Email");
        }

        return Ok(new ResetPasswordDto { Token = token, Email = email });
    }
    
    //reset password
    [HttpPost("resetPassword")]
    public async Task<ActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null) return NotFound("User not found");
            var validateOTP = await _userManager.VerifyUserTokenAsync(user,"Email","ResetFactor", resetPasswordDto.Token);
            if (!validateOTP)
            {
                return BadRequest("Invalid OTP");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user ,token,resetPasswordDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Invalid token or password");
            }

            return Ok("Password reset successfully");
        }

        return BadRequest("Invalid payload");
    }
    
    
 }