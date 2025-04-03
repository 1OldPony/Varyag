using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

		public DbSet<AnythingElse> AnythingElse { get; set; }

		public DbSet<Varyag.Models.Article> Article { get; set; }
	}


	public class VaryagSQLContext : IdentityDbContext<User>
	{
		public VaryagSQLContext(DbContextOptions<VaryagSQLContext> options)
			: base(options)
		{
		}

		public DbSet<Project> Project { get; set; }

		public DbSet<Foto> Foto { get; set; }

		public DbSet<News> News { get; set; }

		public DbSet<AnythingElse> AnythingElse { get; set; }

		public DbSet<Varyag.Models.Article> Article { get; set; }
	}
}








//using Microsoft.AspNet.Identity.EntityFramework;

//namespace Varyag.Models
//{
//	public class VaryagContext : IdentityDbContext<User>
//        {
//            public VaryagContext(DbContextOptions<VaryagContext> options)
//                : base(options)
//            {
//            }

//            public DbSet<Project> Project { get; set; }

//            public DbSet<Foto> Foto { get; set; }

//            public DbSet<News> News { get; set; }

//            public DbSet<AnythingElse> AnythingElse { get; set; }

//            public DbSet<Varyag.Models.Article> Article { get; set; }
//    }


//}