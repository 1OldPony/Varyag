using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Varyag.Models
{
    public class VaryagContext : DbContext
    {
        public VaryagContext (DbContextOptions<VaryagContext> options)
            : base(options)
        {
        }

        public DbSet<Varyag.Models.ShipProject> ShipProject { get; set; }
    }
}
