using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class ProjectsCatalogViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public ProjectsCatalogViewComponent(VaryagContext context)
        {
            db = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(string category, bool plitca, string lengthSort)
        {
            var items = new List<Project>();
            bool boats = false;
            switch (category)
            {
                case "boatrow":
                    items = await db.Project.Where(w => w.BoatRow == true).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "boatsail":
                    items = await db.Project.Where(w => w.BoatSail == true).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "boattraditional":
                    items = await db.Project.Where(w => w.BoatTraditional == true).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "boatyal":
                    items = await db.Project.Where(w => w.BoatYal == true).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "botik":
                    items = await db.Project.Where(w => w.Botik == true).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "katercabin":
                    items = await db.Project.Where(w => w.KaterCabin == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "katerfish":
                    items = await db.Project.Where(w => w.KaterFish == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "katerproject":
                    items = await db.Project.Where(w => w.KaterProject == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "katerrow":
                    items = await db.Project.Where(w => w.KaterRow == true).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "katerpass":
                    items = await db.Project.Where(w => w.KaterPass == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "galleysAndStrugs":
                    items = await db.Project.Where(w => w.LadyaProject == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sailArea";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort)); 
                case "ladyarow":
                    items = await db.Project.Where(w => w.LadyaRow == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sailArea";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "ladyasail":
                    items = await db.Project.Where(w => w.LadyaSail == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sailArea";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "maketstudy":
                    items = await db.Project.Where(w => w.MaketStudy == true).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "motosailer":
                    items = await db.Project.Where(w => w.Motosailer == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "sailboathistorical":
                    items = await db.Project.Where(w => w.SailboatHistorical == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "sailboatproject":
                    items = await db.Project.Where(w => w.SailboatProject == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "sailboatstudy":
                    items = await db.Project.Where(w => w.SailboatStudy == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "shvertbot":
                    items = await db.Project.Where(w => w.Shvertbot == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "yacht":
                    items = await db.Project.Where(w => w.Yacht == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "boat":
                    items = await db.Project.Where(w => w.BoatRow || w.BoatSail || w.BoatTraditional == true ).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "bigboat":
                    items = await db.Project.Where(w => w.BoatYal || w.Botik || w.KaterRow || w.MaketStudy == true).ToListAsync();
                    boats = true;
                    ViewBag.secondCharacteristic = "weight";
                    ViewBag.thirdCharacteristic = "passanger";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "kater":
                    items = await db.Project.Where(w => w.KaterCabin || w.KaterFish || w.KaterProject || w.Motosailer || w.KaterPass == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "ladiy":
                    items = await db.Project.Where(w => w.LadyaRow || w.LadyaSail || w.LadyaProject == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sailArea";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "sailboat":
                    items = await db.Project.Where(w => w.Yacht || w.Shvertbot || w.SailboatStudy || w.SailboatHistorical || w.SailboatProject == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sleepingAreas";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "models":
                    items = await db.Project.Where(w => w.MaketCinema || w.MaketDesign || w.MaketMuseum == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sailArea";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "modelsMakets":
                    items = await db.Project.Where(w => w.MaketMuseum == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sailArea";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                case "other":
                    items = await db.Project.Where(w => w.MaketDesign == true).ToListAsync();
                    ViewBag.secondCharacteristic = "volume";
                    ViewBag.thirdCharacteristic = "sailArea";
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                default:
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats, lengthSort));
            }
        }
    }
}