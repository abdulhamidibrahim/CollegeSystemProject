using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CollegeSystem.BL.DTOs;
using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using User.Management.Services.Models;
using User.Management.Services.Services;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffsController: ControllerBase
{
    private readonly IStaffManager _staffManager;
    private readonly UserManager<Staff> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _config;

    public StaffsController(
        IStaffManager staffManager,
        UserManager<Staff> userManager,
        IEmailService emailService,
        IConfiguration config)
    {
        _staffManager = staffManager;
        _userManager = userManager;
        _emailService = emailService;
        _config = config;
    }
    
     [HttpPost("register")]
    public async Task<ActionResult> Register(StaffRegisterDto staffRegisterDto)
    {
        if (ModelState.IsValid)
        {
            var staff = new Staff()
            {
                //StudentId = 
                UserName  = staffRegisterDto.UserName,
                Email = staffRegisterDto.Email,
                Name = staffRegisterDto.Name,
                Phone = staffRegisterDto.Phone,
                EmailConfirmed = false,
                TwoFactorEnabled = true
            };
            
            IdentityResult result = await _userManager.CreateAsync(staff, staffRegisterDto.Password);
            if (!result.Succeeded)
            {
               
            }
            
            // send email verification to the user
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(staff);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Staffs", new { token, email = staff.Email },
                Request.Scheme);
            var message = new Message(new[] { staff.Email }, "Confirmation email link", confirmationLink!);

            _emailService.SendEmail(message);
            return Ok(
                "Account created successfully, we have sent a confirmation email, please click the link to confirm your email");


        }
        var errors = ModelState.Where (n => n.Value.Errors.Count > 0).ToList ();
        return BadRequest(errors);
    }

    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(StaffRegisterDto staffRegisterDto)
    {
        if (ModelState.IsValid)
        {
           Staff? staff=await _userManager.FindByNameAsync(staffRegisterDto.UserName);
           if (staff != null)
           {
              bool found= await _userManager.CheckPasswordAsync(staff, staffRegisterDto.Password);
              if (found)
              {
                  // create tokens 

                  var claims = new List<Claim>
                  {
                      // Debug.Assert(user.UserName != null, "user.UserName != null");
                      new Claim(ClaimTypes.Name, staff.UserName!),
                      new Claim(ClaimTypes.NameIdentifier, staff.Id.ToString()),
                      new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                  };

                  var roles= await _userManager.GetRolesAsync(staff);
                  foreach (var itemRole in roles)
                  {
                      claims.Add(new Claim(ClaimTypes.Role,itemRole));
                      
                  }

                  SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:secret"]!));
                  SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
                  
                  JwtSecurityToken myToken = new JwtSecurityToken(
                      issuer:_config["JWT:issuer"], // provider
                      audience:_config["JWT:audience"], // consumer 
                      claims:claims,
                      expires:DateTime.Now.AddHours(5),
                      signingCredentials:credentials
                      );
                  // if (staff.TwoFactorEnabled)
                  // {
                  //     var token = await _userManager.GenerateTwoFactorTokenAsync(staff,"Email");
                  // }
                  return Ok( new {
                          token = new JwtSecurityTokenHandler().WriteToken(myToken),
                          expiration=myToken.ValidTo
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
        var passwordResetLink = Url.Action(nameof(ResetPassword), "Staffs", new { token, email = user.Email },Request.Scheme);
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

        return Ok(new  { Token = token, Email = email });
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
    
    
    
    
    [HttpGet]
    public ActionResult<List<StaffReadDto>> GetAll()
    {
        return _staffManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<StaffReadDto?> Get(long id)
    {
        var user = _staffManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(StaffAddDto staffAddDto)
    {
        _staffManager.Add(staffAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(StaffUpdateDto staffUpdateDto)
    {
        _staffManager.Update(staffUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(StaffDeleteDto staffDeleteDto)
    {
        _staffManager.Delete(staffDeleteDto);
        return Ok();
    }
    
}