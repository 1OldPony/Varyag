using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class FotoramaViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public FotoramaViewComponent(VaryagContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? shipProjectId)
        {
            var items = await db.Foto.Where(w => w.ShipProjectID == shipProjectId).ToListAsync();
            ViewBag.ShipId = shipProjectId;
            return View(items);
        }
    }
}