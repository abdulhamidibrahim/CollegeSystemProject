using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CollegeSystem.BL.DTOs.User;
using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParentsController: ControllerBase
{
    private readonly IParentManager _parentManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _config;

    public ParentsController(IParentManager parentManager,
        UserManager<ApplicationUser> userManager, 
        IConfiguration config)
    {
        _parentManager = parentManager;
        _userManager = userManager;
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
            await _userManager.AddToRoleAsync(parent,parentRegisterDto.Role); 
            return Ok("Account created successfully");
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
           ApplicationUser? user=await _userManager.FindByNameAsync(parentRegisterDto.UserName);
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
    
}