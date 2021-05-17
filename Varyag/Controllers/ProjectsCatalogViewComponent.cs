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
        
        public async Task<IViewComponentResult> InvokeAsync(string category, bool plitca)
        {
            var items = new List<Project>();
            bool boats = false;
            switch (category)
            {
                case "boatrow":
                    items = await db.Project.Where(w => w.BoatRow == true).ToListAsync();
                    boats = true;
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "boatsail":
                    items = await db.Project.Where(w => w.BoatSail == true).ToListAsync();
                    boats = true;
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "boattraditional":
                    items = await db.Project.Where(w => w.BoatTraditional == true).ToListAsync();
                    boats = true;
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "boatyal":
                    items = await db.Project.Where(w => w.BoatYal == true).ToListAsync();
                    boats = true;
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "botik":
                    items = await db.Project.Where(w => w.Botik == true).ToListAsync();
                    boats = true;
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "katercabin":
                    items = await db.Project.Where(w => w.KaterCabin == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "katerfish":
                    items = await db.Project.Where(w => w.KaterFish == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "katerproject":
                    items = await db.Project.Where(w => w.KaterProject == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "katerrow":
                    items = await db.Project.Where(w => w.KaterRow == true).ToListAsync();
                    boats = true;
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "katerpass":
                    items = await db.Project.Where(w => w.KaterPass == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "ladyaproject":
                    items = await db.Project.Where(w => w.LadyaProject == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "ladyarow":
                    items = await db.Project.Where(w => w.LadyaRow == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "ladyasail":
                    items = await db.Project.Where(w => w.LadyaSail == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "maketstudy":
                    items = await db.Project.Where(w => w.MaketStudy == true).ToListAsync();
                    boats = true;
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "motosailer":
                    items = await db.Project.Where(w => w.Motosailer == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "sailboathistorical":
                    items = await db.Project.Where(w => w.SailboatHistorical == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "sailboatproject":
                    items = await db.Project.Where(w => w.SailboatProject == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "sailboatstudy":
                    items = await db.Project.Where(w => w.SailboatStudy == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "shvertbot":
                    items = await db.Project.Where(w => w.Shvertbot == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "yacht":
                    items = await db.Project.Where(w => w.Yacht == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "boat":
                    items = await db.Project.Where(w => w.BoatRow || w.BoatSail || w.BoatTraditional == true ).ToListAsync();
                    boats = true;
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "bigboat":
                    items = await db.Project.Where(w => w.BoatYal || w.Botik || w.KaterRow || w.MaketStudy == true).ToListAsync();
                    boats = true;
                    //return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "kater":
                    items = await db.Project.Where(w => w.KaterCabin || w.KaterFish || w.KaterProject || w.Motosailer || w.KaterPass == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "ladiy":
                    items = await db.Project.Where(w => w.LadyaRow || w.LadyaSail || w.LadyaProject == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                case "sailboat":
                    items = await db.Project.Where(w => w.Yacht || w.Shvertbot || w.SailboatStudy || w.SailboatHistorical || w.SailboatProject == true).ToListAsync();
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
                default:
                    if (plitca)
                        return View("Plitca", LittleHelper.ProjectsToSortedViewModel(items, boats));
                    else
                        return View(LittleHelper.ProjectsToSortedViewModel(items, boats));
            }
        }
    }
}