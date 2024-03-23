using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blog_.Net_be.Models
{
    public class Category 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
