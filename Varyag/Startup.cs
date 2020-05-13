using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Internal;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Varyag
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<VaryagContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("VaryagContext")));

            services.AddIdentity<User, IdentityRole>( options => {
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<VaryagContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Accounts/Login";
                options.LoginPath = "/Accounts/Login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(
                routes =>
            {
                routes.MapRoute("default", "{controller=about}/{action=index}/{id?}");
                routes.MapRoute("О нас", "О-нас", defaults: new { controller = "About", action = "AboutUs" });
                routes.MapRoute("Статья", "О-нас/{route}", defaults: new { controller = "About", action = "ArticleDetails" });
                routes.MapRoute("Наши новости", "О-нас/Наши-новости", defaults: new { controller = "About", action = "AllNews" });
                routes.MapRoute("Конкретная новость", "О-нас/Наши-новости/{id}", defaults: new { controller = "About", action = "NewsDetails" });
                routes.MapRoute("Каталог", "Каталог", defaults: new { controller = "Catalog", action = "CatalogNavigation" });
                routes.MapRoute("Каталог лодок", "Каталог/Лодки", defaults: new { controller = "Catalog", action = "Boats" });
                routes.MapRoute("Каталог прогулочных гребных лодок", "Каталог/Лодки/Прогулочные-гребные-лодки", defaults: new { controller = "Catalog", action = "BoatsRow" });
                routes.MapRoute("Каталог прогулочных парусных лодок", "Каталог/Лодки/Прогулочные-парусные-лодки", defaults: new { controller = "Catalog", action = "BoatsSail" });
                routes.MapRoute("Каталог народных лодок", "Каталог/Лодки/Народные-лодки", defaults: new { controller = "Catalog", action = "BoatsTraditional" });
                routes.MapRoute("Каталог шлюпок", "Каталог/Шлюпки", defaults: new { controller = "Catalog", action = "Bigboats" });
                routes.MapRoute("Каталог шлюпок ЯЛ", "Каталог/Шлюпки/Шлюпки-ЯЛ2,ЯЛ4,ЯЛ6", defaults: new { controller = "Catalog", action = "BoatsYal" });
                routes.MapRoute("Каталог ботиков", "Каталог/Шлюпки/Ботики", defaults: new { controller = "Catalog", action = "Botiks" });
                routes.MapRoute("Каталог гребных катеров и вельботов", "Каталог/Шлюпки/Гребные-катера-и-вельботы", defaults: new { controller = "Catalog", action = "KaterRows" });
                routes.MapRoute("Каталог учебных пособий", "Каталог/Шлюпки/Учебные-пособия", defaults: new { controller = "Catalog", action = "MaketsStudy" });
                routes.MapRoute("Каталог катеров", "Каталог/Катера", defaults: new { controller = "Catalog", action = "Motorboats" });
                routes.MapRoute("Каталог мотосейлеров", "Каталог/Катера/Мотосейлеры", defaults: new { controller = "Catalog", action = "Motosailers" });
                routes.MapRoute("Каталог каютных катеров", "Каталог/Катера/Каютные-катера", defaults: new { controller = "Catalog", action = "KaterKabins" });
                routes.MapRoute("Каталог рабочих и рыболовных катеров", "Каталог/Катера/Рабочие-и-рыболовные-катера", defaults: new { controller = "Catalog", action = "KatersFishing" });
                routes.MapRoute("Каталог пассажирских катеров", "Каталог/Катера/Пассажирские-катера", defaults: new { controller = "Catalog", action = "KatersPassanger" });
                routes.MapRoute("Каталог ладей", "Каталог/Ладьи", defaults: new { controller = "Catalog", action = "Ladiy" });
                routes.MapRoute("Каталог парусно-гребных ладей", "Каталог/Ладьи/Парусно-гребные-ладьи", defaults: new { controller = "Catalog", action = "LadyasSailRow" });
                routes.MapRoute("Каталог парусно-моторных ладей", "Каталог/Ладьи/Парусно-моторные-ладьи", defaults: new { controller = "Catalog", action = "LadyasSailMotor" });
                routes.MapRoute("Каталог парусников", "Каталог/Парусники", defaults: new { controller = "Catalog", action = "Sailboats" });
                routes.MapRoute("Каталог парусных яхт", "Каталог/Парусники/Парусные-яхты", defaults: new { controller = "Catalog", action = "Yachts" });
                routes.MapRoute("Каталог швертботов", "Каталог/Парусники/Швертботы", defaults: new { controller = "Catalog", action = "Svertbots" });
                routes.MapRoute("Каталог учебных парусников", "Каталог/Парусники/Учебные-парусники", defaults: new { controller = "Catalog", action = "SailboatsStudy" });
                routes.MapRoute("Каталог исторических парусников", "Каталог/Парусники/Исторические-парусники", defaults: new { controller = "Catalog", action = "SailboatsHistorical" });
                routes.MapRoute("Каталог разных проектов", "Каталог/Разное", defaults: new { controller = "Catalog", action = "Models" });
                routes.MapRoute("Страница конкретного проекта", "Каталог/{route}", defaults: new { controller = "Catalog", action = "ProjectDetails" });
                routes.MapRoute("Страница конкретного разного", "Каталог/Разное/{route}", defaults: new { controller = "Catalog", action = "AnythingDetails" });
            }
            );
        }
    }
}
