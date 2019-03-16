using Microsoft.EntityFrameworkCore;
using PortalCore.Models.Internal.Entites;

namespace PortalCore.DataAccess
{
    public class PagesContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<View> Views { get; set; }

        public PagesContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
