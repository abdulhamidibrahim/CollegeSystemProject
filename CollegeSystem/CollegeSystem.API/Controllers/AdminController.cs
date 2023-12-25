using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CollegeSystem.BL.DTOs.User;
using CollegeSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Core;
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

    public AdminController(UserManager<ApplicationUser> userManager,IEmailService emailService, IConfiguration config)
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
    

// [HttpPost("createRole")]
    // // [Authorize(Roles = "Admin")]
    // public async Task CreateRoles(IServiceProvider serviceProvider,string role)
    // {
    //     //initializing custom roles 
    //
    //     string[] roleNames = { "Admin", "Staff", "Student","Parent" };
    //     var allRoles = roleNames.Append(role);
    //
    //     foreach (var roleName in allRoles)
    //     {
    //         var roleExist = await _roleManager.RoleExistsAsync(roleName);
    //         if (!roleExist)
    //         {
    //             //create the roles and seed them to the database: Question 1
    //             await _roleManager.CreateAsync(new IdentityRole(roleName));
    //         }
    //     }
    //
    //     //Here you could create a super user who will maintain the web app
    //     var powerUser = new Admin
    //     {
    //
    //         UserName = _config["AppSettings:UserName"],
    //         Email = _config["AppSettings:UserEmail"],
    //     };
    //     //Ensure you have these values in your appsettings.json file
    //     string? userPwd = _config["AppSettings:UserPassword"];
    //     var user = await _userManager.FindByEmailAsync(_config["AppSettings:AdminUserEmail"]!);
    //
    //     if (user == null)
    //     {
    //         Debug.Assert(userPwd != null, nameof(userPwd) + " != null");
    //         var createPowerUser = await _userManager.CreateAsync(powerUser, userPwd);
    //         if (createPowerUser.Succeeded)
    //         {
    //             //here we tie the new user to the role
    //             await _userManager.AddToRoleAsync(powerUser, "Admin");
    //
    //         }
    //     }
    // }
}