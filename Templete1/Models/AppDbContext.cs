using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Loyiha_dars.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Konfrensiya> Konfrensiyalar { get; set; }
        public DbSet<Muallif> Mualliflar { get; set; }
        public DbSet<Maqola> Maqolalar { get; set; }


    }
}
