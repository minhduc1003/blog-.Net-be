using blog_.Net_be.CustomRepositories;
using blog_.Net_be.data;
using blog_.Net_be.dto;
using blog_.Net_be.Models;
using blog_.Net_be.Repositories;
using blog_.Net_be.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blog_.Net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserConfig> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly BlogDbContext _context;


        public AuthController(UserManager<UserConfig> userManager,ITokenRepository tokenRepository, BlogDbContext context)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            _context = context;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register) 
        {
            var identityUser = new UserConfig
            {
                FullName = register.FullName,
                UserName = register.UserName,
                Email = register.Email,
            };
            var rs = await userManager.CreateAsync(identityUser, register.Password);
            if (rs.Succeeded)
            {
                  rs = await userManager.AddToRolesAsync(identityUser, new[] {"user"});
                    if(rs.Succeeded)
                    {
                    var user = await userManager.FindByEmailAsync(identityUser.Email);
                    if(user.Id != null)
                    {
                        Author author = new Author
                        {
                            Id = user.Id,
                            Name = user.FullName
                        };
                        await _context.Authors.AddAsync(author);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    }
                
            }
            
            return BadRequest("something went wrong");
            
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
           var user = await userManager.FindByEmailAsync(login.Email);
            if(user != null)
            {
                var check = await userManager.CheckPasswordAsync(user,login.Password);
                if (check)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                     var JwtToken =  tokenRepository.CreateJWTToken(user,roles.ToList());
/*                        var token = new TokenDto
                        {
                            Token = JwtToken,
                            id = user.Id
                        };*/
                        return Ok(new { Token=JwtToken, id = user.Id });
                    }
                } 
                
            }
            return BadRequest("Password or email invalid");

        }
        [HttpGet]
        [Route("getUserById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                return Ok(new { UserId=user.Id , name= user.FullName });
            }
            return BadRequest("empty");
        }
    }
}
