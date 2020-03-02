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

        [Route("Каталог/Лодки")]
             public IActionResult Boats()
        {
            ViewData["Title"] = "Купить деревянные лодки от производителя";
            ViewData["Keywords"] = "Купить деревянные лодки, Прогулочные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных прогулочных парусных, а также гребных и народных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boats";
            return View();
        }

        [Route("Каталог/Лодки/Прогулочные_гребные_лодки")]
        public IActionResult BoatsRow()
        {
            ViewData["Title"] = "Купить деревянные прогулочные гребные лодки от производителя";
            ViewData["Keywords"] = "Деревянные лодки, Гребные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных прогулочных гребных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatsrow";
            return View();
        }

        [Route("Каталог/Лодки/Прогулочные_парусные_лодки")]
        public IActionResult BoatsSail()
        {
            ViewData["Title"] = "Купить деревянные прогулочные парусные лодки от производителя";
            ViewData["Keywords"] = "Купить прогулочные лодки, Парусные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных прогулочных парусных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatssail";
            return View();
        }

        [Route("Каталог/Лодки/Народные_лодки")]
        public IActionResult BoatsTraditional()
        {
            ViewData["Title"] = "Купить деревянные традиционные народные лодки от производителя";
            ViewData["Keywords"] = "Купить народные лодки, традиционные лодки от производителя";
            ViewData["Description"] = "Каталог деревянных народных лодок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatstraditional";
            return View();
        }

        [Route("Каталог/Шлюпки")]
        public IActionResult Bigboats()
        {
            ViewData["Title"] = "Купить деревянные шлюпки от производителя";
            ViewData["Keywords"] = "Купить деревянные шлюпки, Классические шлюпки от производителя";
            ViewData["Description"] = "Каталог деревянных шлюпок производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "bigboats";
            return View();
        }

        [Route("Каталог/Шлюпки/Шлюпки_ЯЛ2,ЯЛ4,ЯЛ6")]
        public IActionResult BoatsYal()
        {
            ViewData["Title"] = "Купить шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6 от производителя";
            ViewData["Keywords"] = "Купить шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6, деревянные шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6 от производителя";
            ViewData["Description"] = "Каталог шлюпок ЯЛ 2, ЯЛ 4, ЯЛ 6 производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatsyal";
            return View();
        }

        [Route("Каталог/Шлюпки/Ботики")]
        public IActionResult Botiks()
        {
            ViewData["Title"] = "Купить исторические ботики от производителя";
            ViewData["Keywords"] = "Купить ботики, Исторические ботики от производителя";
            ViewData["Description"] = "Каталог исторических ботиков производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "botiks";
            return View();
        }

        [Route("Каталог/Шлюпки/Гребные_катера_и_вельботы")]
        public IActionResult KaterRows()
        {
            ViewData["Title"] = "Купить  гребные катера от производителя";
            ViewData["Keywords"] = "Купить гребные катера, Гребные катера от производителя";
            ViewData["Description"] = "Каталог гребных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerrows";
            return View();
        }

        [Route("Каталог/Шлюпки/Учебные_пособия")]
        public IActionResult MaketsStudy()
        {
            ViewData["Title"] = "Учебные макеты судов";
            ViewData["Keywords"] = "Купить учебные макеты, Учебные макеты судов";
            ViewData["Description"] = "Учебные макеты для изучения конструкции судов";
            ViewBag.TopPic = "maketsstudy";
            return View();
        }

        [Route("Каталог/Катера")]
        public IActionResult Motorboats()
        {
            ViewData["Title"] = "Купить катера от производителя";
            ViewData["Keywords"] = "Купить катера, Катера от производителя";
            ViewData["Description"] = "Каталог каютных, рыболовных и пассажирских катеров, а также мотосейлеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katera";
            return View();
        }

        [Route("Каталог/Катера/Мотосейлеры")]
        public IActionResult Motosailers()
        {
            ViewData["Title"] = "Купить мотосейлеры от производителя";
            ViewData["Keywords"] = "Купить мотосейлеры, Мотосейлеры от производителя";
            ViewData["Description"] = "Каталог мотосейлеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "motosailers"; 
            return View();
        }

        [Route("Каталог/Катера/Каютные_катера")]
        public IActionResult KaterKabins()
        {
            ViewData["Title"] = "Купить каютные катера от производителя";
            ViewData["Keywords"] = "Купить каютные катера, Каютные катера от производителя";
            ViewData["Description"] = "Каталог каютных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerkabins";
            return View();
        }

        [Route("Каталог/Катера/Рабочие_и_рыболовные_катера")]
        public IActionResult KatersFishing()
        {
            ViewData["Title"] = "Купить рабочие и рыболовные катера от производителя";
            ViewData["Keywords"] = "Купить рыболовные катера, Рабочие рыболовные катера от производителя";
            ViewData["Description"] = "Каталог рабочих и рыболовных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katersfishing";
            return View();
        }

        [Route("Каталог/Катера/Пассажирские_катера")]
        public IActionResult KatersPassanger()
        {
            ViewData["Title"] = "Купить пассажирские катера от производителя";
            ViewData["Keywords"] = "Купить пассажирские катера, Пассажирские катера от производителя";
            ViewData["Description"] = "Каталог пассажирских катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerspassanger";
            return View();
        }

        [Route("Каталог/Ладьи")]
        public IActionResult Ladiy()
        {
            ViewData["Title"] = "Купить ладьи от производителя";
            ViewData["Keywords"] = "Купить исторические ладьи, Ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-гребных и парусно-моторных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladiy";
            return View();
        }

        [Route("Каталог/Ладьи/Парусно-гребные_ладьи")]
        public IActionResult LadyasSailRow()
        {
            ViewData["Title"] = "Купить парусно-гребные ладьи от производителя";
            ViewData["Keywords"] = "Купить исторические ладьи, Парусно-гребные ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-гребных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladyassailrow";
            return View();
        }

        [Route("Каталог/Ладьи/Парусно-моторные_ладьи")]
        public IActionResult LadyasSailMotor()
        {
            ViewData["Title"] = "Купить парусно-моторные ладьи от производителя";
            ViewData["Keywords"] = "Купить исторические ладьи, Парусно-моторные ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-моторных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladyassailmotor";
            return View();
        }

        [Route("Каталог/Парусники")]
        public IActionResult Sailboats()
        {
            ViewData["Title"] = "Купить парусники от производителя";
            ViewData["Keywords"] = "Купить деревянные парусники, Классические парусники от производителя";
            ViewData["Description"] = "Каталог деревянных яхт, швертботов, а также учебных и исторических парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboats";
            return View();
        }

        [Route("Каталог/Парусники/Парусные_яхты")]
        public IActionResult Yachts()
        {
            ViewData["Title"] = "Купить яхты от производителя";
            ViewData["Keywords"] = "Купить деревянные яхты, Классические деревянные яхты от производителя";
            ViewData["Description"] = "Каталог деревянных яхт производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "yachts";
            return View();
        }

        [Route("Каталог/Парусники/Швертботы")]
        public IActionResult Svertbots()
        {
            ViewData["Title"] = "Купить швертботы от производителя";
            ViewData["Keywords"] = "Купить швертботы, Швертботы от производителя";
            ViewData["Description"] = "Каталог швертботов производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "svertbots";
            return View();
        }

        [Route("Каталог/Парусники/Учебные_парусники")]
        public IActionResult SailboatsStudy()
        {
            ViewData["Title"] = "Купить учебные парусники от производителя";
            ViewData["Keywords"] = "Купить учебные парусники, Учебные парусники от производителя";
            ViewData["Description"] = "Каталог учебных парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboatsstudy";
            return View();
        }

        [Route("Каталог/Парусники/Исторические_парусники")]
        public IActionResult SailboatsHistorical()
        {
            ViewData["Title"] = "Купить исторические парусники от производителя";
            ViewData["Keywords"] = "Купить исторические парусники, Деревянные исторические парусники от производителя";
            ViewData["Description"] = "Каталог исторических парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboatshistorical";
            return View();
        }

        [Route("Каталог/Разное")]
        public IActionResult Models()
        {
            List<AnythingElse> anythingItems = db.AnythingElse.ToList();
            ViewData["Title"] = "Разные заказы";
            ViewData["Keywords"] = "Дизайнерские решения на морскую тему, Корабли-инсталяции";
            ViewData["Description"] = "Дизайнерские решения, инсталяции и прочие нестандартные поекты, производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "makets";

            return View(anythingItems);
        }
        
        [Route("Каталог/Проект_{id}")]
        public async Task<IActionResult> ProjectDetails(int? id)
        {
            ViewBag.TopPic = "details";

            if (id == null)
            {
                return NotFound();
            }

            var project = await db.Project
                .FirstOrDefaultAsync(m => m.ProjectID == id);
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

        [Route("Каталог/Разное_{id}")]
        public async Task<IActionResult> AnythingDetails(int? id)
        {
            ViewBag.TopPic = "details";

            if (id == null)
            {
                return NotFound();
            }

            var project = await db.AnythingElse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}
