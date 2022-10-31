using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TSLP_Website_Merge.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Sellers> sellers { get; set; }

        public DbSet<Partner> partners { get; set; }

        public DbSet<Content> content { get; set; }

        public DbSet<Roster> roster { get; set; }

    }
}
