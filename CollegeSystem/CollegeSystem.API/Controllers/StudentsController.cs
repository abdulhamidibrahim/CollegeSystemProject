using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using CollegeSystem.BL.DTOs;
using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using FCISystem.DAL;
using FileUploadingWebAPI.Filter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using User.Management.Services.Models;
using User.Management.Services.Services;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController: ControllerBase
{
    public IConfiguration _config { get; }
    private readonly IStudentManager _studentManager;
    private readonly UserManager<Student> _userManager;
    private readonly IEmailService _emailService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IFileRepo _fileRepo;

    public StudentsController(
        IStudentManager studentManager,
        UserManager<Student> userManager,
        IEmailService emailService,
        IConfiguration config, IWebHostEnvironment webHostEnvironment, IFileRepo fileRepo)
    {
        _config = config;
        _webHostEnvironment = webHostEnvironment;
        _fileRepo = fileRepo;
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
                Phone = studentRegisterDto.Phone,
                Level = studentRegisterDto.Level,
                Term = studentRegisterDto.Term,
                Gender = studentRegisterDto.Gender,
                Ssn = studentRegisterDto.Ssn,
                EmailConfirmed = false,
            };
            
            // check if the user is already registered
            // var user = await _userManager.FindByEmailAsync(student.Email);
            // if (user != null) return BadRequest(new { message = "User already registered", status = "error"});
            
            IdentityResult result = await _userManager.CreateAsync(student, studentRegisterDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Unable to create Student", status = "error",error = result.Errors});
            }

            try
            {
                await _userManager.AddToRoleAsync(student, nameof(student));
            }catch (Exception e)
            {
                await _userManager.DeleteAsync(student);
                return BadRequest(new { message = "Unable to add to role", status = "error",error = e.Message});
            }
            
            
            
            // send email verification to the user
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(student);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Students", new { token, email = student.Email },
                Request.Scheme);
            var message = new Message(new[] { student.Email }, "Confirmation email link", confirmationLink!);

            _emailService.SendEmail(message);
            return Ok(
                    new
                {
                    message = "Student created successfully, check your email for confirmation",
                    status = "success"
                });

            
        }
        var errors = ModelState.Where (n => n.Value.Errors.Count > 0).ToList ();
        return BadRequest(new { message = "Invalid data", status = "error",error = errors});
    }

    // send email
    [HttpPost]
    [Route("ResendEmail")]
    public async Task<ActionResult> SendConfirmationEmail(string email)
    {
        var student = await _userManager.FindByEmailAsync(email);
        if (student == null) return NotFound(new { message = "Student not found", status = "error"});
        if (student.EmailConfirmed) return BadRequest(new { message = "Email already confirmed", status = "error"});

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(student);
        var confirmationLink = Url.Action(nameof(ConfirmEmail), "Students", new { token, email = student.Email },
            Request.Scheme);
        var message = new Message(new[] { student.Email }, "Confirmation email link", confirmationLink!);

        _emailService.SendEmail(message);
        return Ok(new { message = "Email sent successfully", status = "success"});
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        if (ModelState.IsValid)
        {
           Student? student=await _userManager.FindByNameAsync(loginDto.UserName);
           if (student != null)
           {
              bool found= await _userManager.CheckPasswordAsync(student, loginDto.Password);
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
              
              return BadRequest(new { message = "Invalid username or password", status = "error",});
           }
           
           return BadRequest(new { message = "Invalid username or password", status = "error"});
        }
        return BadRequest(new { message = "Input a valid data!", status = "error"});
    }
    
    
     [HttpGet]
    [Route("confirmEmail")]
    public async Task<ActionResult> ConfirmEmail(string token, string email)
    {
        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
        {
            return NotFound(new { message = "Invalid token or Email", status = "error"});
        }

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return NotFound(new { message = "User not found", status = "error"});

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return BadRequest(new { message = "Email confirmation failed,Invalid token", status = "error"});
        }

        return Ok(new { message = "Email confirmed successfully", status = "success"});
    }
    
    [HttpPost("forgotPassword")]
    public async Task<ActionResult> ForgotPassword(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return BadRequest(new { message = "User not found", status = "error"});
        var token = await _userManager.GenerateUserTokenAsync(user, "Email","ResetFactor");
        var passwordResetLink = Url.Action(nameof(ResetPassword), "Students", new { token, email = user.Email },Request.Scheme);
        var message = new Message(new[] { user.Email }!, "Reset password link", passwordResetLink!);
        _emailService.SendEmail(message);
        return Ok(new { message = "Password reset link sent successfully", status = "success"});
    }
    
    [HttpGet("resetPassword")]
    public ActionResult ResetPassword(string token, string email)
    {
        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
        {
            return NotFound(new { message = "Invalid token or Email", status = "error" });
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
            if (user == null) return NotFound(new { message = "User not found", status = "error"});
            var validateOTP = await _userManager.VerifyUserTokenAsync(user,"Email","ResetFactor", resetPasswordDto.Token);
            if (!validateOTP)
            {
                return BadRequest(new { message = "Invalid OTP", status = "error"});
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user ,token,resetPasswordDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Password reset failed,Invalid token or password", status = "error",error = result.Errors});
            }

            return Ok(new { message = "Password reset successfully", status = "success"});
        }

        return BadRequest(new { message = "Invalid data", status = "error"});
    }
    
    
    //logout
    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
        return Ok(new { message = "Logged out successfully", status = "success"});
    }
    
    
    [HttpPost("uploadImage/{courseId}")]
    [ImageValidator]
    public IActionResult UploadImage(IFormFile image,long id)
    {
        var file = new File()
        {
            Name = image.Name,
            Extension = image.ContentType,
        };
        
        var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", image.FileName);

        using FileStream fileStream = new(path, FileMode.Create);
        fileStream.CopyTo(fileStream);

         _studentManager.AddImageAsync(image,id);
        return Ok(new { message = "Image uploaded successfully", status = "success"});
    }
    
    
    [HttpPut("updateImage/{courseId}")]
    public IActionResult UpdateImage(int id, IFormFile file)
    {
       _studentManager.UpdateImageAsync(id, file);

        return Ok(new { message = "Image updated successfully", status = "success"});
    }
    
    [HttpGet("getImage/{courseId}")]
    public  IActionResult  GetImage(int id)
    {
       var uploadedFile = _fileRepo.GetById(id);

       if (uploadedFile is null) return null;

       return Ok(Path.Combine(_webHostEnvironment.WebRootPath, "uploads", uploadedFile.Name));
       
    }
    
    [HttpDelete("{courseId}")]
    public IActionResult DeleteImage(int id)
    {
       _studentManager.DeleteImage(id);

        return Ok(new { message = "Image deleted successfully", status = "success"});
    }


    [HttpGet("GetAll")]
    public ActionResult<List<StudentReadDto>> GetAll()
    {
        return _studentManager.GetAll();
    }
    
    [HttpGet("{courseId}")]
    public ActionResult<StudentReadDto?> Get(long id)
    {
        var user = _studentManager.Get(id);
        if (user == null) return NotFound(new { message = "Student not found", status = "error"});
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(StudentAddDto studentAddDto)
    {
        _studentManager.Add(studentAddDto);
        return Ok(new { message = "Student added successfully", status = "success"});
    }
    
    
    [HttpDelete("/deleteStudent/{courseId}")]
    public ActionResult Delete(long id)
    {
        _studentManager.Delete(id);
        return Ok(new { message = "Student deleted successfully", status = "success"});
    }
    //update student
    [HttpPut("update/{courseId}")]
    public IActionResult UpdateStudent(long id, StudentUpdateDto studentUpdateDto)
    {
        _studentManager.Update(id,studentUpdateDto);
        return Ok(new { message = "Student updated successfully", status = "success"});
    }
    
}