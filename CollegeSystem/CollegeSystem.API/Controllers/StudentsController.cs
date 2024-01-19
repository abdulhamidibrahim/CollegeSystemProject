using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CollegeSystem.BL.DTOs;
using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using FileUploadingWebAPI.Filter;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using User.Management.Services.Models;
using User.Management.Services.Services;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController: ControllerBase
{
    public IConfiguration _config { get; }
    private readonly IStudentManager _studentManager;
    private readonly UserManager<Student> _userManager;
    private readonly IEmailService _emailService;

    public StudentsController(
        IStudentManager studentManager,
        UserManager<Student> userManager,
        IEmailService emailService,
        IConfiguration config
        )
    {
        _config = config;
        _studentManager = studentManager;
        _userManager = userManager;
        _emailService = emailService;
    }
    
    
    [HttpPost("register")]
    public async Task<ActionResult> Register(StudentRegisterDto studentRegisterDto)
    {
        if (ModelState.IsValid)
        {
            var student = new Student()
            {
                UserName  = studentRegisterDto.UserName,
                Email = studentRegisterDto.Email,
                ArabicName = studentRegisterDto.Name,
                EmailConfirmed = false,
            };
            
            IdentityResult result = await _userManager.CreateAsync(student, studentRegisterDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            
            // send email verification to the user
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(student);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Students", new { token, email = student.Email },
                Request.Scheme);
            var message = new Message(new[] { student.Email }, "Confirmation email link", confirmationLink!);

            _emailService.SendEmail(message);
            return Ok(
                "Account created successfully, we have sent a confirmation email, please click the link to confirm your email");

            
        }
        var errors = ModelState.Where (n => n.Value.Errors.Count > 0).ToList ();
        return BadRequest(errors);
    }

    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(StudentLoginDto studentLoginDto)
    {
        if (ModelState.IsValid)
        {
           Student? student=await _userManager.FindByNameAsync(studentLoginDto.UserName);
           if (student != null)
           {
              bool found= await _userManager.CheckPasswordAsync(student, studentLoginDto.Password);
              if (found)
              {
                  // create tokens 

                  var claims = new List<Claim>
                  {
                      // Debug.Assert(user.UserName != null, "user.UserName != null");
                      new Claim(ClaimTypes.Name, student.UserName!),
                      new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                      new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                  };

                  var roles= await _userManager.GetRolesAsync(student);
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
        var passwordResetLink = Url.Action(nameof(ResetPassword), "Students", new { token, email = user.Email },Request.Scheme);
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
    
    
    
    
    
    [HttpPost("uploadImage/{id}")]
    [ImageValidator]
    public IActionResult UploadImage(IFormFile iamge,long id)
    {
         _studentManager.AddImageAsync(iamge,id);
        return Ok("Image Uploaded Successfully");
    }
    
    
    [HttpPut("{id}")]
    public IActionResult UpdateImage(int id, IFormFile file)
    {
       _studentManager.UpdateImageAsync(id, file);

        return Ok("Image Updated Successfully");
    }
    
    [HttpGet("getImage/{id}")]
    public  IActionResult  GetImage(int id)
    {
        _studentManager.GetImage(id);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteImage(int id)
    {
       _studentManager.DeleteImage(id);

        return Ok("Image deleted Successfully");
    }


    [HttpGet("GetAll")]
    public ActionResult<List<StudentReadDto>> GetAll()
    {
        return _studentManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<StudentReadDto?> Get(long id)
    {
        var user = _studentManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(StudentAddDto studentAddDto)
    {
        _studentManager.Add(studentAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(StudentUpdateDto studentUpdateDto)
    {
        _studentManager.Update(studentUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(StudentDeleteDto studentDeleteDto)
    {
        _studentManager.Delete(studentDeleteDto);
        return Ok();
    }
    
}