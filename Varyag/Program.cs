using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Varyag.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Конфигурация сервисов
builder.Services.Configure<CookiePolicyOptions>(options =>
{
	options.CheckConsentNeeded = context => true;
	options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddControllersWithViews(); // Заменяет AddMvc()

// Добавление контекста базы данных
builder.Services.AddDbContext<VaryagContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("VaryagContext"),
					 ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("VaryagContext"))));

builder.Services.AddDbContext<VaryagSQLContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("VaryagSQLContext")));

// Настройка Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<VaryagContext>();

// Настройка Application Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
	options.AccessDeniedPath = "/Accounts/Login";
	options.LoginPath = "/Accounts/Login";
});

var app = builder.Build();

// Конфигурация middleware
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication(); // Добавляем аутентификацию
app.UseAuthorization();

// Настройка маршрутов
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=about}/{action=index}/{id?}");

app.MapControllerRoute(
	name: "О нас",
	pattern: "o-nas",
	defaults: new { controller = "About", action = "AboutUs" });

app.MapControllerRoute(
	name: "Наши новости",
	pattern: "o-nas/nashi-novosti",
	defaults: new { controller = "About", action = "AllNews" });

app.MapControllerRoute(
	name: "Статья",
	pattern: "o-nas/stati",
	defaults: new { controller = "About", action = "AllArticles" });

app.MapControllerRoute(
	name: "Статья",
	pattern: "o-nas/stati/{route}",
	defaults: new { controller = "About", action = "ArticleDetails" });

app.MapControllerRoute(
	name: "Конкретная новость",
	pattern: "o-nas/{id}",
	defaults: new { controller = "About", action = "NewsDetails" });

app.MapControllerRoute(
	name: "Каталог",
	pattern: "katalog",
	defaults: new { controller = "Catalog", action = "CatalogNavigation" });

app.MapControllerRoute(
	name: "Поиск по каталогу",
	pattern: "katalog/poisk",
	defaults: new { controller = "Catalog", action = "Search" });

app.MapControllerRoute(
	name: "Каталог лодок",
	pattern: "katalog/lodki",
	defaults: new { controller = "Catalog", action = "Boats" });

app.MapControllerRoute(
	name: "Каталог прогулочных гребных лодок",
	pattern: "katalog/lodki/progulochnye-grebnye-lodki",
	defaults: new { controller = "Catalog", action = "BoatsRow" });

app.MapControllerRoute(
	name: "Каталог прогулочных парусных лодок",
	pattern: "katalog/lodki/progulochnye-parusnye-lodki",
	defaults: new { controller = "Catalog", action = "BoatsSail" });

app.MapControllerRoute(
	name: "Каталог народных лодок",
	pattern: "katalog/lodki/narodnye-lodki",
	defaults: new { controller = "Catalog", action = "BoatsTraditional" });

app.MapControllerRoute(
	name: "Каталог шлюпок",
	pattern: "katalog/shlyupki",
	defaults: new { controller = "Catalog", action = "Bigboats" });

app.MapControllerRoute(
	name: "Каталог шлюпок ЯЛ",
	pattern: "katalog/shlyupki/shlyupki-yal2yal4yal6",
	defaults: new { controller = "Catalog", action = "BoatsYal" });

app.MapControllerRoute(
	name: "Каталог ботиков",
	pattern: "katalog/shlyupki/botiki",
	defaults: new { controller = "Catalog", action = "Botiks" });

app.MapControllerRoute(
	name: "Каталог гребных катеров и вельботов",
	pattern: "katalog/shlyupki/grebnye-katera-i-velboty",
	defaults: new { controller = "Catalog", action = "KaterRows" });

app.MapControllerRoute(
	name: "Каталог учебных пособий",
	pattern: "katalog/shlyupki/uchebnye-posobiya",
	defaults: new { controller = "Catalog", action = "MaketsStudy" });

app.MapControllerRoute(
	name: "Каталог катеров",
	pattern: "katalog/katera",
	defaults: new { controller = "Catalog", action = "Motorboats" });

app.MapControllerRoute(
	name: "Каталог мотосейлеров",
	pattern: "katalog/katera/motoseylery",
	defaults: new { controller = "Catalog", action = "Motosailers" });

app.MapControllerRoute(
	name: "Каталог каютных катеров",
	pattern: "katalog/katera/kayutnye-katera",
	defaults: new { controller = "Catalog", action = "KaterKabins" });

app.MapControllerRoute(
	name: "Каталог рабочих и рыболовных катеров",
	pattern: "katalog/katera/rabochie-i-rybolovnye-katera",
	defaults: new { controller = "Catalog", action = "KatersFishing" });

app.MapControllerRoute(
	name: "Каталог пассажирских катеров",
	pattern: "katalog/katera/passazhirskie-katera",
	defaults: new { controller = "Catalog", action = "KatersPassanger" });

app.MapControllerRoute(
	name: "Каталог ладей",
	pattern: "katalog/ladi",
	defaults: new { controller = "Catalog", action = "Ladiy" });

app.MapControllerRoute(
	name: "Каталог парусно-гребных ладей",
	pattern: "katalog/ladi/parusno-grebnye-ladi",
	defaults: new { controller = "Catalog", action = "LadyasSailRow" });

app.MapControllerRoute(
	name: "Каталог парусно-моторных ладей",
	pattern: "katalog/ladi/parusno-motornye-ladi",
	defaults: new { controller = "Catalog", action = "LadyasSailMotor" });

app.MapControllerRoute(
	name: "Каталог стругов и галер",
	pattern: "katalog/ladi/strugi-i-galery",
	defaults: new { controller = "Catalog", action = "GalleysAndStrugs" });

app.MapControllerRoute(
	name: "Каталог парусников",
	pattern: "katalog/parusniki",
	defaults: new { controller = "Catalog", action = "Sailboats" });

app.MapControllerRoute(
	name: "Каталог парусных яхт",
	pattern: "katalog/parusniki/parusnye-yahty",
	defaults: new { controller = "Catalog", action = "Yachts" });

app.MapControllerRoute(
	name: "Каталог швертботов",
	pattern: "katalog/parusniki/shvertboty",
	defaults: new { controller = "Catalog", action = "Svertbots" });

app.MapControllerRoute(
	name: "Каталог учебных парусников",
	pattern: "katalog/parusniki/uchebnye-parusniki",
	defaults: new { controller = "Catalog", action = "SailboatsStudy" });

app.MapControllerRoute(
	name: "Каталог исторических парусников",
	pattern: "katalog/parusniki/istoricheskie-parusniki",
	defaults: new { controller = "Catalog", action = "SailboatsHistorical" });

app.MapControllerRoute(
	name: "Каталог разного",
	pattern: "katalog/raznoe",
	defaults: new { controller = "Catalog", action = "Models" });

app.MapControllerRoute(
	name: "Каталог разного",
	pattern: "katalog/raznoe/modeli-i-makety",
	defaults: new { controller = "Catalog", action = "ModelsMakets" });

app.MapControllerRoute(
	name: "Каталог разного",
	pattern: "katalog/raznoe/prochaya-produkciya",
	defaults: new { controller = "Catalog", action = "Other" });

app.MapControllerRoute(
	name: "Страница конкретного проекта",
	pattern: "katalog/{route}",
	defaults: new { controller = "Catalog", action = "ProjectDetails" });

app.MapControllerRoute(
	name: "Страница конкретного разного",
	pattern: "katalog/raznoe/{route}",
	defaults: new { controller = "Catalog", action = "AnythingDetails" });

app.Run();









//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;

//namespace Varyag
//{
//	public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateWebHostBuilder(args).Build().Run();
//        }

//        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//            WebHost.CreateDefaultBuilder(args)
//                .UseStartup<Startup>();
//    }
//}
