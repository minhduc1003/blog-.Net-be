using blog_.Net_be.CustomRepositories;
using blog_.Net_be.dto;
using blog_.Net_be.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace blog_.Net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserConfig> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<UserConfig> userManager,ITokenRepository tokenRepository)
        {
         
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
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
                 string role = "user";
                  rs = await userManager.AddToRolesAsync(identityUser, new[] {"user"});
                    if(rs.Succeeded)
                    {
                       return Ok();
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
                        var token = new TokenDto
                        {
                            Token = JwtToken,
                        };
                    return Ok(token);
                    }
                } 
                
            }
            return BadRequest("Password or email invalid");

        }
    }
}
