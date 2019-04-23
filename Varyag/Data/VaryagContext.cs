using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Models
{
        public class VaryagContext : IdentityDbContext<User>
        {
            public VaryagContext(DbContextOptions<VaryagContext> options)
                : base(options)
            {
            }

            public DbSet<Project> Project { get; set; }

            public DbSet<Foto> Foto { get; set; }

            public DbSet<News> News { get; set; }
    }


}