using Microsoft.EntityFrameworkCore;
using PortalCore.Models.Internal.Entites;

namespace PortalCore.DataAccess
{
    public class PagesContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Conditional> Conditionals { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

        public PagesContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
