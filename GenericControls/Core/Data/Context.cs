using GenericControls.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Data
{
    public class Context : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Partial> Partials { get; set; }

        public Context(DbContextOptions options)
            : base(options)
        {
        }
    }
}
