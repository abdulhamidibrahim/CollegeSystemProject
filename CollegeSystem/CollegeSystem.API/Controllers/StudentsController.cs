using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController: ControllerBase
{
    public IConfiguration _config { get; }
    private readonly IStudentManager _studentManager;
    private readonly UserManager<Student> _userManager;

    public StudentsController(
        IStudentManager studentManager,
        UserManager<Student> userManager,
        IConfiguration config)
    {
        _config = config;
        _studentManager = studentManager;
        _userManager = userManager;
    }
    
    
    [HttpPost("register")]
    public async Task<ActionResult> Register(StudentRegisterDto studentRegisterDto)
    {
        if (ModelState.IsValid)
        {
            var student = new Student()
            {
                Id = studentRegisterDto.StudentCode,
                UserName  = studentRegisterDto.UserName,
                Email = studentRegisterDto.Email,
                ArabicName = studentRegisterDto.Name,
                Phone = studentRegisterDto.Phone,
                UniversityEmail = studentRegisterDto.UniversityEmail,
                ParentEmail = studentRegisterDto.ParentEmail,
                ParentPhone = studentRegisterDto.ParentPhone,
                Ssn = studentRegisterDto.Ssn,
                EmailConfirmed = false,
            };
            
            IdentityResult result = await _userManager.CreateAsync(student, studentRegisterDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(student,studentRegisterDto.Role);
                return Ok("Account created successfully");
            }
        }
        var errors = ModelState.Where (n => n.Value.Errors.Count > 0).ToList ();
        return BadRequest(errors);
    }

    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(StudentRegisterDto studentRegisterDto)
    {
        if (ModelState.IsValid)
        {
           Student? student=await _userManager.FindByNameAsync(studentRegisterDto.UserName);
           if (student != null)
           {
              bool found= await _userManager.CheckPasswordAsync(student, studentRegisterDto.Password);
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