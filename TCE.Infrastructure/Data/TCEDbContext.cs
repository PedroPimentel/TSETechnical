using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Domain.Entities;

namespace TCE.Infrastructure.Data
{
    public class TCEDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }

        public TCEDbContext(DbContextOptions<TCEDbContext> options) : base(options)
        {

        }
    }
}
