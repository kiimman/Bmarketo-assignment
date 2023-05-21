using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webbmvcapp.Models;
using webbmvcapp.Models.Identity;
using webbmvcapp.ViewModels;

namespace webbmvcapp.Contexts
{
    public class IdentityContext : IdentityDbContext<CustomIdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ContactViewModel> Contacts { get; set; }
    }
}
