using Exambilet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exambilet.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

      public AppDbContext(DbContextOptions options) : base(options)
        {
        } 
       
        public DbSet<Game> Games { get; set; }
    }
}
