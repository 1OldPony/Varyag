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
        private readonly VaryagContext _context;

        public CatalogController(VaryagContext context)
        {
            _context = context;
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
            ViewData["Keywords"] = "Купить классические лодки, Парусные лодки от производителя";
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
            ViewData["Title"] = "Купить деревянные шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6 от производителя";
            ViewData["Keywords"] = "Купить шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6, деревянные шлюпки ЯЛ 2, ЯЛ 4, ЯЛ 6 от производителя";
            ViewData["Description"] = "Каталог деревянных шлюпок ЯЛ 2, ЯЛ 4, ЯЛ 6 производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "boatsyal";
            return View();
        }

        [Route("Каталог/Шлюпки/Ботики")]
        public IActionResult Botiks()
        {
            ViewData["Title"] = "Купить деревянные исторические ботики от производителя";
            ViewData["Keywords"] = "Купить деревянные ботики, Исторические ботики от производителя";
            ViewData["Description"] = "Каталог исторических ботиков производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "botiks";
            return View();
        }

        [Route("Каталог/Шлюпки/Гребные_катера_и_вельботы")]
        public IActionResult KaterRows()
        {
            ViewData["Title"] = "Купить  деревянные гребные катера от производителя";
            ViewData["Keywords"] = "Купить гребные катера, Деревянные гребные катера от производителя";
            ViewData["Description"] = "Каталог деревянных гребных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerrows";
            return View();
        }

        [Route("Каталог/Катера")]
        public IActionResult Motorboats()
        {
            ViewData["Title"] = "Купить  деревянные катера от производителя";
            ViewData["Keywords"] = "Купить деревянные катера, Деревянные катера от производителя";
            ViewData["Description"] = "Каталог деревянных каютных, рыболовных и пассажирских катеров, а также мотосейлеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katera";
            return View();
        }

        [Route("Каталог/Катера/Мотосейлеры")]
        public IActionResult Motosailers()
        {
            ViewData["Title"] = "Купить деревянные мотосейлеры от производителя";
            ViewData["Keywords"] = "Купить деревянные мотосейлеры, Мотосейлеры от производителя";
            ViewData["Description"] = "Каталог мотосейлеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "motosailers"; 
            return View();
        }

        [Route("Каталог/Катера/Каютные_катера")]
        public IActionResult KaterKabins()
        {
            ViewData["Title"] = "Купить деревянные каютные катера от производителя";
            ViewData["Keywords"] = "Купить каютные катера, Деревянные каютные катера от производителя";
            ViewData["Description"] = "Каталог деревянных каютных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerkabins";
            return View();
        }

        [Route("Каталог/Катера/Рабочие_и_рыболовные_катера")]
        public IActionResult KatersFishing()
        {
            ViewData["Title"] = "Купить деревянные рабочие и рыболовные катера от производителя";
            ViewData["Keywords"] = "Купить рыболовные катера, Деревянные рабочие рыболовные катера от производителя";
            ViewData["Description"] = "Каталог деревянных рабочих и рыболовных катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katersfishing";
            return View();
        }

        [Route("Каталог/Катера/Пассажирские_катера")]
        public IActionResult KatersPassanger()
        {
            ViewData["Title"] = "Купить деревянные пассажирские катера от производителя";
            ViewData["Keywords"] = "Купить пассажирские катера, деревянные пассажирские катера от производителя";
            ViewData["Description"] = "Каталог деревянных пассажирских катеров производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerspassanger";
            return View();
        }

        [Route("Каталог/Катера/Проекты_катеров")]
        public IActionResult KaterProjects()
        {
            ViewData["Title"] = "Готовые проекты деревянных катеров от производителя";
            ViewData["Keywords"] = "Проекты деревянных катеров, Купить деревянные катера";
            ViewData["Description"] = "Проекты деревянных катеров, разработанных на верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "katerprojects";
            return View();
        }

        [Route("Каталог/Ладьи")]
        public IActionResult Ladiy()
        {
            ViewData["Title"] = "Купить деревянные ладьи от производителя";
            ViewData["Keywords"] = "Купить исторические ладьи, Деревянные ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-гребных и парусно-моторных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladiy";
            return View();
        }

        [Route("Каталог/Ладьи/Парусно-гребные_ладьи")]
        public IActionResult LadyasSailRow()
        {
            ViewData["Title"] = "Купить деревянные парусно-гребные ладьи от производителя";
            ViewData["Keywords"] = "Купить деревянные лодьи, Парусно-гребные ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-гребных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladyassailrow";
            return View();
        }

        [Route("Каталог/Ладьи/Парусно-моторные_ладьи")]
        public IActionResult LadyasSailMotor()
        {
            ViewData["Title"] = "Купить деревянные парусно-моторные ладьи от производителя";
            ViewData["Keywords"] = "Купить деревянные лодьи, Парусно-моторные ладьи от производителя";
            ViewData["Description"] = "Каталог парусно-моторных ладей производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladyassailmotor";
            return View();
        }

        [Route("Каталог/Ладьи/Проекты_ладей")]
        public IActionResult LadyaProjects()
        {
            ViewData["Title"] = "Проекты деревянных ладей";
            ViewData["Keywords"] = "Проекты деревянных ладей, Купить ладью";
            ViewData["Description"] = "Проекты деревянных ладей, разработанных на верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "ladyaprojects";
            return View();
        }

        [Route("Каталог/Парусники")]
        public IActionResult Sailboats()
        {
            ViewData["Title"] = "Купить деревянные парусники от производителя";
            ViewData["Keywords"] = "Купить деревянные парусники, Классические парусники от производителя";
            ViewData["Description"] = "Каталог деревянных яхт, швертботов, а также учебных и исторических парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboats";
            return View();
        }

        [Route("Каталог/Парусники/Парусные_яхты")]
        public IActionResult Yachts()
        {
            ViewData["Title"] = "Купить деревянные яхты от производителя";
            ViewData["Keywords"] = "Купить деревянные яхты, Классические деревянные яхты от производителя";
            ViewData["Description"] = "Каталог деревянных яхт производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "yachts";
            return View();
        }

        [Route("Каталог/Парусники/Швертботы")]
        public IActionResult Svertbots()
        {
            ViewData["Title"] = "Купить деревянные швертботы от производителя";
            ViewData["Keywords"] = "Купить деревянные швертботы, Швертботы от производителя";
            ViewData["Description"] = "Каталог швертботов производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "svertbots";
            return View();
        }

        [Route("Каталог/Парусники/Учебные_парусники")]
        public IActionResult SailboatsStudy()
        {
            ViewData["Title"] = "Купить деревянные учебные парусники от производителя";
            ViewData["Keywords"] = "Купить учебные парусники, Деревянные учебные парусники от производителя";
            ViewData["Description"] = "Каталог деревянных учебных парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboatsstudy";
            return View();
        }

        [Route("Каталог/Парусники/Исторические_парусники")]
        public IActionResult SailboatsHistorical()
        {
            ViewData["Title"] = "Купить деревянные исторические парусники от производителя";
            ViewData["Keywords"] = "Купить исторические парусники, Деревянные исторические парусники от производителя";
            ViewData["Description"] = "Каталог деревянных исторических парусников производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboatshistorical";
            return View();
        }

        [Route("Каталог/Парусники/Проекты_парусников")]
        public IActionResult SailboatsProjects()
        {
            ViewData["Title"] = "Проекты деревянных парусников";
            ViewData["Keywords"] = "Проекты деревянных парусников, Купить парусник";
            ViewData["Description"] = "Проекты парусников, разработанных на верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "sailboatsprojects";
            return View();
        }

        [Route("Каталог/Макеты")]
        public IActionResult Models()
        {
            ViewData["Title"] = "Макеты парусников, шлюпок и других судов";
            ViewData["Keywords"] = "Купить макеты судов, Макеты шлюпок ладей парусников";
            ViewData["Description"] = "Макеты парусников, шлюпок и других судов производства верфи деревянного судостроения Варяг";
            ViewBag.TopPic = "makets";
            return View();
        }

        [Route("Каталог/Макеты/Учебные_макеты_судов_и_кораблей")]
        public IActionResult MaketsStudy()
        {
            ViewData["Title"] = "Учебные макеты судов";
            ViewData["Keywords"] = "Купить учебные макеты, Учебные макеты судов";
            ViewData["Description"] = "Учебные макеты для изучения конструкции судов";
            ViewBag.TopPic = "maketsstudy";
            return View();
        }

        [Route("Каталог/Макеты/Макеты_судов_и_кораблей_для_фильмов")]
        public IActionResult MaketsCinema()
        {
            ViewData["Title"] = "Макеты судов и кораблей для фильмов";
            ViewData["Keywords"] = "Купить макеты для съемок, Макеты судов и кораблей для фильмов";
            ViewData["Description"] = "Макеты судов и кораблей для использования в съемках художественных или документальных фильмах";
            ViewBag.TopPic = "maketscinema";
            return View();
        }

        [Route("Каталог/Макеты/Макеты_судов_для_музеев")]
        public IActionResult MaketsMuseum()
        {
            ViewData["Title"] = "Макеты судов для музеев";
            ViewData["Keywords"] = "Купить макеты судов для музеев, Макеты парусников и шлюпок для музеев";
            ViewData["Description"] = "Макеты судов и кораблей в качестве музейных экспонатов, а также судов и кораблей-музеев в качестве помещений для выставок";
            ViewBag.TopPic = "maketsmuseum";
            return View();
        }

        [Route("Каталог/Проект_{id}")]
        public async Task<IActionResult> ProjectDetails(int? id)
        {
            ViewBag.TopPic = "details";

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            if (project.BoatRow || project.BoatSail || project.BoatTraditional || project.BoatYal || project.Botik || project.KaterRow)
            {
                ViewBag.TTHType = "boats&bigboats";
            }
            else
            {
                ViewBag.TTHType = "AllOthers";
            }
            return View(project);
        }
    }
}
