using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blog_.Net_be.data
{
    public class AuthDbContext:IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options ) :base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string user = "2b7457ef-8e5a-4f46-94f3-fd8115a77b48";
            string admin = "8b29a3c3-955c-4ceb-a141-ccf0bacb60f7";

            var role = new List<IdentityRole>
            {
                new IdentityRole {
                    Id= user,
                    ConcurrencyStamp=user,
                    Name="user",
                    NormalizedName="user".ToUpper()
                },
                new IdentityRole {
                    Id= admin,
                    ConcurrencyStamp=admin,
                    Name="admin",
                    NormalizedName="admin".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(role);
        }
    }
}
