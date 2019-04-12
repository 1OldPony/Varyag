using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class ProjectFotoViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public ProjectFotoViewComponent(VaryagContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int shipProjectId)
        {
            var items = await db.Foto.Where(w => w.ShipProjectID == shipProjectId).ToListAsync();
            return View(items);
        }

        //public async Task<List<Foto>> GetProjectFotosAsync(int shipId)
        //{
        //    return db.Foto.Where(w => w.ShipProjectID == shipId).ToListAsync();
        //}
    }
}
