using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Domain.Entities;
using TCE.Infrastructure.Data.Configurations;

namespace TCE.Infrastructure.Data
{
    public class TCEDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }

        public TCEDbContext(DbContextOptions<TCEDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompraConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
