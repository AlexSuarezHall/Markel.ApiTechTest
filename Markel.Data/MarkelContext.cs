using Markel.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Markel.Data
{
    public class MarkelContext : DbContext
    {
        public MarkelContext(DbContextOptions<MarkelContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Claim> Claims { get; set; } = null!;
        public DbSet<ClaimType> ClaimTypes { get; set; } = null!;

    }
}
