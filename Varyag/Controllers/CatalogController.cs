using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class CatalogController : Controller
    {
        private readonly VaryagContext db;

        public CatalogController(VaryagContext context)
        {
            db = context;
        }
        
        //public IActionResult Catalog()
        //{
        //    return RedirectToAction("Sailboats");
        //}

        public IActionResult CatalogSort(string category, bool plitca, string lengthSort)
        {            
            return ViewComponent("ProjectsCatalog", new { category, plitca, lengthSort });
        }

        public int ProjectsSearchCount(string value)
        {
            List<Project> Projects = db.Project.Where(p => p.Name.Contains(value)).ToList();
            return Projects.Count();
        }

        public IActionResult Search(string searchText)
        {
            ViewData["Title"] = String.Concat("Поиск ", "\"", searchText, "\"");
            ViewBag.SearchText = searchText;
            //List<Project> Projects = db.Project.Where(p => p.Name.Contains(searchText)).ToList();
            return View();
        }

        public IActionResult CatalogNavigation()
        {
            ViewData["Title"] = "Купить деревянные лодки от производителя";
            ViewData["Keywords"] = "Купить деревянные лодки, Прогулочные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных прогулочных парусных, а также гребных и народных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boats";
            ViewBag.catalogPage = "catalog";
            return View();
        }

        public IActionResult Boats()
        {
            ViewData["Title"] = "Купить деревянные лодки от производителя";
            ViewData["Keywords"] = "Купить деревянные лодки, Прогулочные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных прогулочных парусных, а также гребных и народных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boats";
            ViewBag.catalogPage = "boats";
            return View();
        }

        public IActionResult BoatsRow()
        {
            ViewData["Title"] = "Купить деревянные прогулочные гребные лодки от производителя";
            ViewData["Keywords"] = "Деревянные лодки, Гребные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных прогулочных гребных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatsrow";
            ViewBag.catalogPage = "boats";
            return View();
        }

        public IActionResult BoatsSail()
        {
            ViewData["Title"] = "Купить деревянные прогулочные парусные лодки от производителя";
            ViewData["Keywords"] = "Купить прогулочные лодки, Парусные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных прогулочных парусных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatssail";
            ViewBag.catalogPage = "boats";
            return View();
        }

        public IActionResult BoatsTraditional()
        {
            ViewData["Title"] = "Купить деревянные традиционные народные лодки от производителя";
            ViewData["Keywords"] = "Купить народные лодки, традиционные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных народных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatstraditional";
            ViewBag.catalogPage = "boats";
            return View();
        }

        public IActionResult Bigboats()
        {
            ViewData["Title"] = "Купить деревянные шлюпки от производителя";
            ViewData["Keywords"] = "Купить деревянные шлюпки, Классические шлюпки от производителя";
            ViewData["Description"] = "Каталог деревянных шлюпок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "bigboats";
            ViewBag.catalogPage = "bigboats";
            return View();
        }

        public IActionResult BoatsYal()
        {
            ViewData["Title"] = "Купить шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6 от производителя";
            ViewData["Keywords"] = "Купить шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6, деревянные шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6 от производителя";
            ViewData["Description"] = "Каталог шлюпок ЯЛ 2, ЯЛ 4, ЯЛ 6 производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatsyal";
            ViewBag.catalogPage = "bigboats";
            return View();
        }

        public IActionResult Botiks()
        {
            ViewData["Title"] = "Купить исторические ботики от производителя";
            ViewData["Keywords"] = "Купить ботики, Исторические ботики от производителя";
            ViewData["Description"] = "Каталог исторических ботиков производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "botiks";
            ViewBag.catalogPage = "bigboats";
            return View();
        }

        public IActionResult KaterRows()
        {
            ViewData["Title"] = "Купить  гребные катера от производителя";
            ViewData["Keywords"] = "Купить гребные катера, Гребные катера от производителя";
            ViewData["Description"] = "Каталог гребных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerrows";
            ViewBag.catalogPage = "bigboats";
            return View();
        }

        public IActionResult MaketsStudy()
        {
            ViewData["Title"] = "Учебные макеты судов";
            ViewData["Keywords"] = "Купить учебные макеты, Учебные макеты судов";
            ViewData["Description"] = "Учебные макеты для изучения конструкции судов";
            ViewBag.TopPic = "maketsstudy";
            ViewBag.catalogPage = "bigboats";
            return View();
        }

        public IActionResult Motorboats()
        {
            ViewData["Title"] = "Купить катера от производителя";
            ViewData["Keywords"] = "Купить катера, Катера от производителя";
            ViewData["Description"] = "Каталог каютных, рыболовных и пассажирских катеров, а также мотосейлеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katera";
            ViewBag.catalogPage = "motorboats";
            return View();
        }

        public IActionResult Motosailers()
        {
            ViewData["Title"] = "Купить мотосейлеры от производителя";
            ViewData["Keywords"] = "Купить мотосейлеры, Мотосейлеры от производителя";
            ViewData["Description"] = "Каталог мотосейлеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "motosailers";
            ViewBag.catalogPage = "motorboats";
            return View();
        }

        public IActionResult KaterKabins()
        {
            ViewData["Title"] = "Купить каютные катера от производителя";
            ViewData["Keywords"] = "Купить каютные катера, Каютные катера от производителя";
            ViewData["Description"] = "Каталог каютных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerkabins";
            ViewBag.catalogPage = "motorboats";
            return View();
        }

        public IActionResult KatersFishing()
        {
            ViewData["Title"] = "Купить рабочие и рыболовные катера от производителя";
            ViewData["Keywords"] = "Купить рыболовные катера, Рабочие рыболовные катера от производителя";
            ViewData["Description"] = "Каталог рабочих и рыболовных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katersfishing";
            ViewBag.catalogPage = "motorboats";
            return View();
        }

        public IActionResult KatersPassanger()
        {
            ViewData["Title"] = "Купить пассажирские катера от производителя";
            ViewData["Keywords"] = "Купить пассажирские катера, Пассажирские катера от производителя";
            ViewData["Description"] = "Каталог пассажирских катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerspassanger";
            ViewBag.catalogPage = "motorboats";
            return View();
        }

        public IActionResult Ladiy()
        {
            ViewData["Title"] = "Купить ладьи от производителя";
            ViewData["Keywords"] = "Купить исторические ладьи, Ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-гребных и парусно-моторных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladiy";
            ViewBag.catalogPage = "ladiy";
            return View();
        }

        public IActionResult LadyasSailRow()
        {
            ViewData["Title"] = "Купить парусно-гребные ладьи от производителя";
            ViewData["Keywords"] = "Купить исторические ладьи, Парусно-гребные ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-гребных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladyassailrow";
            ViewBag.catalogPage = "ladiy";
            return View();
        }

        public IActionResult LadyasSailMotor()
        {
            ViewData["Title"] = "Купить парусно-моторные ладьи от производителя";
            ViewData["Keywords"] = "Купить исторические ладьи, Парусно-моторные ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-моторных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladyassailmotor";
            ViewBag.catalogPage = "ladiy";
            return View();
        }
        
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////

        public IActionResult GalleysAndStrugs()
        {
            ViewData["Title"] = "Купить струги и галеры от производителя";
            ViewData["Keywords"] = "Купить деревянные струги, Деревянные галеры от производителя";
            ViewData["Description"] = "Каталог деревянных галер и стругов производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "galleysAndStrugs";
            ViewBag.catalogPage = "ladiy";
            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////

        public IActionResult Sailboats()
        {
            ViewData["Title"] = "Купить парусники от производителя";
            ViewData["Keywords"] = "Купить деревянные парусники, Классические парусники от производителя";
            ViewData["Description"] = "Каталог деревянных яхт, швертботов, а также учебных и исторических парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboats";
            ViewBag.catalogPage = "sailboats";
            return View();
        }

        public IActionResult Yachts()
        {
            ViewData["Title"] = "Купить яхты от производителя";
            ViewData["Keywords"] = "Купить деревянные яхты, Классические деревянные яхты от производителя";
            ViewData["Description"] = "Каталог деревянных яхт производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "yachts";
            ViewBag.catalogPage = "sailboats";
            return View();
        }
        
        public IActionResult Svertbots()
        {
            ViewData["Title"] = "Купить швертботы от производителя";
            ViewData["Keywords"] = "Купить швертботы, Швертботы от производителя";
            ViewData["Description"] = "Каталог швертботов производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "svertbots";
            ViewBag.catalogPage = "sailboats";
            return View();
        }

        public IActionResult SailboatsStudy()
        {
            ViewData["Title"] = "Купить учебные парусники от производителя";
            ViewData["Keywords"] = "Купить учебные парусники, Учебные парусники от производителя";
            ViewData["Description"] = "Каталог учебных парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboatsstudy";
            ViewBag.catalogPage = "sailboats";
            return View();
        }
        
        public IActionResult SailboatsHistorical()
        {
            ViewData["Title"] = "Купить исторические парусники от производителя";
            ViewData["Keywords"] = "Купить исторические парусники, Деревянные исторические парусники от производителя";
            ViewData["Description"] = "Каталог исторических парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboatshistorical";
            ViewBag.catalogPage = "sailboats";
            return View();
        }

        public IActionResult Models()
        {
            ViewData["Title"] = "Разные заказы";
            ViewData["Keywords"] = "Дизайнерские решения на морскую тему, Корабли-инсталяции";
            ViewData["Description"] = "Дизайнерские решения, инсталяции модели шлюпок и кораблей, учебные макеты и прочие нестандартные поекты, производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "makets";
            ViewBag.catalogPage = "models";

            return View();
        }
        public IActionResult ModelsMakets()
        {
            ViewData["Title"] = "Модели и макеты";
            ViewData["Keywords"] = "Модели кораблей, учебные макеты шлюпок";
            ViewData["Description"] = "Модели и макеты различных кораблей и шлюпок, учебные пособия для морских училищ и клубов юнных моряков производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "makets";
            ViewBag.catalogPage = "models";
            ViewBag.redLine = "makets";

            return View();
        }
        public IActionResult Other()
        {
            ViewData["Title"] = "Прочая продукция";
            ViewData["Keywords"] = "Дизайнерские решения на морскую тему, Корабли-инсталяции";
            ViewData["Description"] = "Дизайнерские решения, инсталяции и прочие нестандартные поекты производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "makets";
            ViewBag.catalogPage = "models";
            ViewBag.redLine = "other";

            return View();
        }

        public async Task<IActionResult> ProjectDetails(string route)
        {
            if (route == null)
            {
                return NotFound();
            }

            var project = await db.Project
                .FirstOrDefaultAsync(m => m.Route == route);

            ViewBag.TopPic = "details";
            ViewData["Title"] = project.Name;

            if (project.BoatRow == true || project.BoatSail == true || project.BoatTraditional == true)
            {
                ViewData["Keywords"] = "Купить деревянные лодки, Прогулочные лодки от производителя";
                ViewData["Description"] = "Каталог деревянных прогулочных парусных, а также гребных и народных лодок производства верфи деревянного судостроения Варяг";
            }
            else if (project.BoatYal == true || project.Botik == true || project.KaterRow == true || project.MaketStudy == true)
            {
                ViewData["Keywords"] = "Купить деревянные шлюпки, Классические шлюпки от производителя";
                ViewData["Description"] = "Каталог деревянных шлюпок производства верфи деревянного судостроения Варяг";
            }
            else if (project.KaterCabin == true || project.KaterFish == true || project.KaterPass == true || project.Motosailer == true)
            {
                ViewData["Keywords"] = "Купить катера, Катера от производителя";
                ViewData["Description"] = "Каталог каютных, рыболовных и пассажирских катеров, а также мотосейлеров производства верфи деревянного судостроения Варяг";
            }
            else if (project.LadyaSail == true || project.LadyaRow == true || project.LadyaProject == true)
            {
                ViewData["Keywords"] = "Купить исторические ладьи, Ладьи от производителя";
                ViewData["Description"] = "Каталог парусно-гребных и парусно-моторных ладей производства верфи деревянного судостроения Варяг";
            }
            else if (project.SailboatHistorical == true || project.SailboatProject == true || project.SailboatStudy == true || project.Shvertbot == true || project.Yacht == true)
            {
                ViewData["Keywords"] = "Купить деревянные парусники, Классические парусники от производителя";
                ViewData["Description"] = "Каталог деревянных яхт, швертботов, а также учебных и исторических парусников производства верфи деревянного судостроения Варяг";
            }
            ViewBag.hideMulka = project.MaketCinema;

            if (project == null)
            {
                return NotFound();
            }

            if (project.BoatRow || project.BoatSail || project.BoatTraditional || project.BoatYal || project.Botik || project.KaterRow || project.MaketStudy)
            {
                ViewBag.TTHType = "boats&bigboats";
            }
            else
            {
                ViewBag.TTHType = "AllOthers";
            }
            return View(project);
        }

        public async Task<IActionResult> AnythingDetails(string route)
        {

            if (route == null)
            {
                return NotFound();
            }

            var project = await db.AnythingElse
                .FirstOrDefaultAsync(m => m.Route == route);

            ViewBag.TopPic = "details";
            ViewData["Title"] = project.Name;
            ViewData["Keywords"] = "Дизайнерские решения на морскую тему, Корабли-инсталяции";
            ViewData["Description"] = "Дизайнерские решения, инсталяции и прочие нестандартные поекты, производства верфи деревянного судостроения Варяг";

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}
