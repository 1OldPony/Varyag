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
                routes.MapRoute("О нас", "o-nas", defaults: new { controller = "About", action = "AboutUs" });
                routes.MapRoute("Наши новости", "o-nas/nashi-novosti", defaults: new { controller = "About", action = "AllNews" });
                routes.MapRoute("Статья", "o-nas/stati", defaults: new { controller = "About", action = "AllArticles" });
                routes.MapRoute("Статья", "o-nas/stati/{route}", defaults: new { controller = "About", action = "ArticleDetails" });
                /*тут будет конкретная статья - про верфь, она станет главной для раздела "о нас"*/routes.MapRoute("Конкретная новость", "o-nas/{id}", defaults: new { controller = "About", action = "NewsDetails" });
                
                //routes.MapRoute("Наши новости", "О-нас/Наши-новости", defaults: new { controller = "About", action = "AllNews" });
                //routes.MapRoute("Конкретная новость", "О-нас/Наши-новости/{id}", defaults: new { controller = "About", action = "NewsDetails" });
                routes.MapRoute("Каталог", "katalog", defaults: new { controller = "Catalog", action = "CatalogNavigation" });
                routes.MapRoute("Каталог лодок", "katalog/lodki", defaults: new { controller = "Catalog", action = "Boats" });
                routes.MapRoute("Каталог прогулочных гребных лодок", "katalog/lodki/progulochnye-grebnye-lodki", defaults: new { controller = "Catalog", action = "BoatsRow" });
                routes.MapRoute("Каталог прогулочных парусных лодок", "katalog/lodki/progulochnye-parusnye-lodki", defaults: new { controller = "Catalog", action = "BoatsSail" });
                routes.MapRoute("Каталог народных лодок", "katalog/lodki/narodnye-lodki", defaults: new { controller = "Catalog", action = "BoatsTraditional" });
                routes.MapRoute("Каталог шлюпок", "katalog/shlyupki", defaults: new { controller = "Catalog", action = "Bigboats" });
                routes.MapRoute("Каталог шлюпок ЯЛ", "katalog/shlyupki/shlyupki-yal2yal4yal6", defaults: new { controller = "Catalog", action = "BoatsYal" });
                routes.MapRoute("Каталог ботиков", "katalog/shlyupki/botiki", defaults: new { controller = "Catalog", action = "Botiks" });
                routes.MapRoute("Каталог гребных катеров и вельботов", "katalog/shlyupki/grebnye-katera-i-velboty", defaults: new { controller = "Catalog", action = "KaterRows" });
                routes.MapRoute("Каталог учебных пособий", "katalog/shlyupki/uchebnye-posobiya", defaults: new { controller = "Catalog", action = "MaketsStudy" });
                routes.MapRoute("Каталог катеров", "katalog/katera", defaults: new { controller = "Catalog", action = "Motorboats" });
                routes.MapRoute("Каталог мотосейлеров", "katalog/katera/motoseylery", defaults: new { controller = "Catalog", action = "Motosailers" });
                routes.MapRoute("Каталог каютных катеров", "katalog/katera/kayutnye-katera", defaults: new { controller = "Catalog", action = "KaterKabins" });
                routes.MapRoute("Каталог рабочих и рыболовных катеров", "katalog/katera/rabochie-i-rybolovnye-katera", defaults: new { controller = "Catalog", action = "KatersFishing" });
                routes.MapRoute("Каталог пассажирских катеров", "katalog/katera/passazhirskie-katera", defaults: new { controller = "Catalog", action = "KatersPassanger" });
                /*Может вместо ладей сказать исторические/средневековые?*/routes.MapRoute("Каталог ладей", "katalog/ladi", defaults: new { controller = "Catalog", action = "Ladiy" });
                routes.MapRoute("Каталог парусно-гребных ладей", "katalog/ladi/parusno-grebnye-ladi", defaults: new { controller = "Catalog", action = "LadyasSailRow" });
                routes.MapRoute("Каталог парусно-моторных ладей", "katalog/ladi/parusno-motornye-ladi", defaults: new { controller = "Catalog", action = "LadyasSailMotor" });
                routes.MapRoute("Каталог стругов и галер", "katalog/ladi/strugi-i-galery", defaults: new { controller = "Catalog", action = "GalleysAndStrugs" });
                routes.MapRoute("Каталог парусников", "katalog/parusniki", defaults: new { controller = "Catalog", action = "Sailboats" });
                routes.MapRoute("Каталог парусных яхт", "katalog/parusniki/parusnye-yahty", defaults: new { controller = "Catalog", action = "Yachts" });
                routes.MapRoute("Каталог швертботов", "katalog/parusniki/shvertboty", defaults: new { controller = "Catalog", action = "Svertbots" });
                routes.MapRoute("Каталог учебных парусников", "katalog/parusniki/uchebnye-parusniki", defaults: new { controller = "Catalog", action = "SailboatsStudy" });
                routes.MapRoute("Каталог исторических парусников", "katalog/parusniki/istoricheskie-parusniki", defaults: new { controller = "Catalog", action = "SailboatsHistorical" });
                routes.MapRoute("Каталог разного", "katalog/raznoe", defaults: new { controller = "Catalog", action = "Models" });
                routes.MapRoute("Каталог разного", "katalog/raznoe/modeli-i-makety", defaults: new { controller = "Catalog", action = "ModelsMakets" });
                routes.MapRoute("Каталог разного", "katalog/raznoe/prochaya-produkciya", defaults: new { controller = "Catalog", action = "Other" });
                routes.MapRoute("Страница конкретного проекта", "katalog/{route}", defaults: new { controller = "Catalog", action = "ProjectDetails" });
                routes.MapRoute("Страница конкретного разного", "katalog/raznoe/{route}", defaults: new { controller = "Catalog", action = "AnythingDetails" });
            }
            );
        }
    }
}
