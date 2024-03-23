using Microsoft.AspNetCore.Identity;

namespace blog_.Net_be.CustomRepositories
{
    public interface ITokenRepository
    {
       string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
