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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Model)
                .WithMany(m => m.ChildProperties)
                .HasForeignKey(p => p.ModelId);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.ChildModel)
                .WithMany(m => m.ParentProperties)
                .HasForeignKey(p => p.ChildModelId);
        }
    }
}
