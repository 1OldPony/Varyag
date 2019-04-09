using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Models
{
        public class VaryagContext : DbContext
        {
            public VaryagContext(DbContextOptions<VaryagContext> options)
                : base(options)
            {
            }

            public DbSet<Project> Project { get; set; }

            public DbSet<Foto> Foto { get; set; }

            public DbSet<News> News { get; set; }

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    modelBuilder.Entity<Project>(eb =>
            //    {
            //        eb.Property(b => b.Deep).HasColumnType("decimal(10, 1)");
            //        eb.Property(b => b.Length).HasColumnType("decimal(10, 1)");
            //        eb.Property(b => b.SailArea).HasColumnType("decimal(10, 1)");
            //        eb.Property(b => b.Volume).HasColumnType("decimal(10, 1)");
            //        eb.Property(b => b.Windth).HasColumnType("decimal(10, 1)");
            //    });
            //}
        }


}