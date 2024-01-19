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
public class ParentsController: ControllerBase
{
    private readonly IParentManager _parentManager;
    private readonly UserManager<Parent> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _config;

    public ParentsController(IParentManager parentManager,
        UserManager<Parent> userManager, 
        IEmailService emailService,
        IConfiguration config)
    {
        _parentManager = parentManager;
        _userManager = userManager;
        _emailService = emailService;
        _config = config;
    }
    
    
    [HttpPost("register")]
    public async Task<ActionResult> Register(ParentRegisterDto parentRegisterDto)
    {
        if (ModelState.IsValid)
        {
            Parent parent = new Parent() 
            {
                UserName = parentRegisterDto.UserName,
                Email = parentRegisterDto.Email,
                Name = parentRegisterDto.Name,
                Phone = parentRegisterDto.Phone,
                EmailConfirmed = false,
            };
            
            IdentityResult result = await _userManager.CreateAsync(parent, parentRegisterDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);  
            }
            
            // send email verification to the user
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(parent);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Parents", new { token, email = parent.Email },
                Request.Scheme);
            var message = new Message(new[] { parent.Email }, "Confirmation email link", confirmationLink!);

            _emailService.SendEmail(message);
            return Ok(
                "Account created successfully, we have sent a confirmation email, please click the link to confirm your email");
            
        }
        
        var errors = ModelState.Where (n => n.Value.Errors.Count > 0).ToList ();
        return BadRequest(errors);
    }

    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(ParentRegisterDto parentRegisterDto)
    {
        if (ModelState.IsValid)
        {
           Parent? user=await _userManager.FindByNameAsync(parentRegisterDto.UserName);
           if (user != null)
           {
              bool found= await _userManager.CheckPasswordAsync(user, parentRegisterDto.Password);
              if (found)
              {
                  // create tokens 

                  var claims = new List<Claim>
                  {
                      // Debug.Assert(user.UserName != null, "user.UserName != null");
                      new Claim(ClaimTypes.Name, user.UserName!),
                      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                      new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                  };

                  var roles= await _userManager.GetRolesAsync(user);
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
    public ActionResult<List<ParentReadDto>> GetAll()
    {
        return _parentManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<ParentReadDto?> Get(long id)
    {
        var user = _parentManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(ParentAddDto parentAddDto)
    {
        _parentManager.Add(parentAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(ParentUpdateDto parentUpdateDto)
    {
        _parentManager.Update(parentUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(ParentDeleteDto parentDeleteDto)
    {
        _parentManager.Delete(parentDeleteDto);
        return Ok();
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
        var token = await _userManager.GenerateUserTokenAsync(user,"Email","ResetFactor");
        var passwordResetLink = Url.Action(nameof(ResetPassword), "Parents", new { token, email = user.Email },Request.Scheme);
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