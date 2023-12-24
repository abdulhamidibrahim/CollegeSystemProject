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
public class StaffsController: ControllerBase
{
    private readonly IStaffManager _staffManager;
    private readonly UserManager<Staff> _userManager;
    private readonly IConfiguration _config;

    public StaffsController(
        IStaffManager staffManager,
        UserManager<Staff> userManager,
        IConfiguration config)
    {
        _staffManager = staffManager;
        _userManager = userManager;
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
            };
            
            IdentityResult result = await _userManager.CreateAsync(staff, staffRegisterDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(staff,staffRegisterDto.Role);
                return Ok("Account created successfully");
            }
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