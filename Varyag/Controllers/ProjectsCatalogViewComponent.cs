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
        
        public async Task<IViewComponentResult> InvokeAsync(string category)
        {
            var items = new List<Project>();
            switch (category)
            {
                case "boatrow":
                    items = await db.Project.Where(w => w.BoatRow == true).ToListAsync();
                    break;
                case "boatsail":
                    items = await db.Project.Where(w => w.BoatSail == true).ToListAsync();
                    break;
                case "boattraditional":
                    items = await db.Project.Where(w => w.BoatTraditional == true).ToListAsync();
                    break;
                case "boatyal":
                    items = await db.Project.Where(w => w.BoatYal == true).ToListAsync();
                    break;
                case "botik":
                    items = await db.Project.Where(w => w.Botik == true).ToListAsync();
                    break;
                case "katercabin":
                    items = await db.Project.Where(w => w.KaterCabin == true).ToListAsync();
                    break;
                case "katerfish":
                    items = await db.Project.Where(w => w.KaterFish == true).ToListAsync();
                    break;
                case "katerproject":
                    items = await db.Project.Where(w => w.KaterProject == true).ToListAsync();
                    break;
                case "katerrow":
                    items = await db.Project.Where(w => w.KaterRow == true).ToListAsync();
                    break;
                case "katerpass":
                    items = await db.Project.Where(w => w.KaterPass == true).ToListAsync();
                    break;
                case "ladyaproject":
                    items = await db.Project.Where(w => w.LadyaProject == true).ToListAsync();
                    break;
                case "ladyarow":
                    items = await db.Project.Where(w => w.LadyaRow == true).ToListAsync();
                    break;
                case "ladyasail":
                    items = await db.Project.Where(w => w.LadyaSail == true).ToListAsync();
                    break;
                case "maketcinema":
                    items = await db.Project.Where(w => w.MaketCinema == true).ToListAsync();
                    break;
                case "maketdesign":
                    items = await db.Project.Where(w => w.MaketDesign == true).ToListAsync();
                    break;
                case "maketmuseum":
                    items = await db.Project.Where(w => w.MaketMuseum == true).ToListAsync();
                    break;
                case "maketstudy":
                    items = await db.Project.Where(w => w.MaketStudy == true).ToListAsync();
                    break;
                case "motosailer":
                    items = await db.Project.Where(w => w.Motosailer == true).ToListAsync();
                    break;
                case "sailboathistorical":
                    items = await db.Project.Where(w => w.SailboatHistorical == true).ToListAsync();
                    break;
                case "sailboatproject":
                    items = await db.Project.Where(w => w.SailboatProject == true).ToListAsync();
                    break;
                case "sailboatstudy":
                    items = await db.Project.Where(w => w.SailboatStudy == true).ToListAsync();
                    break;
                case "shvertbot":
                    items = await db.Project.Where(w => w.Shvertbot == true).ToListAsync();
                    break;
                case "yacht":
                    items = await db.Project.Where(w => w.Yacht == true).ToListAsync();
                    break;
                case "boat":
                    items = await db.Project.Where(w => w.BoatRow || w.BoatSail || w.BoatTraditional == true ).ToListAsync();
                    break;
                case "bigboat":
                    items = await db.Project.Where(w => w.BoatYal || w.Botik || w.KaterRow == true).ToListAsync();
                    break;
                case "kater":
                    items = await db.Project.Where(w => w.KaterCabin || w.KaterFish || w.KaterProject || w.Motosailer || w.KaterPass == true).ToListAsync();
                    break;
                case "ladiy":
                    items = await db.Project.Where(w => w.LadyaRow || w.LadyaSail || w.LadyaProject == true).ToListAsync();
                    break;
                case "sailboat":
                    items = await db.Project.Where(w => w.Yacht || w.Shvertbot || w.SailboatStudy || w.SailboatHistorical || w.SailboatProject == true).ToListAsync();
                    break;
                case "maket":
                    items = await db.Project.Where(w => w.MaketCinema || w.MaketDesign || w.MaketMuseum|| w.MaketStudy == true).ToListAsync();
                    break;
                default:
                    break;
            }

            return View(items);
        }
    }
}