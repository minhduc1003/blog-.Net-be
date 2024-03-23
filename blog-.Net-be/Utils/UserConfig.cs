using Microsoft.AspNetCore.Identity;

namespace blog_.Net_be.Utils
{
    public class UserConfig:IdentityUser
    {
        public string FullName { get; set; }
    }
}
