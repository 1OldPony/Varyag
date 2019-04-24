using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Varyag.Models;

namespace Varyag.Controllers
{
    [Authorize]
    public class ProjectFotoViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public ProjectFotoViewComponent(VaryagContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? shipProjectId, int? newsId)
        {
            var items = await db.Foto.Where(w => w.ShipProjectID == shipProjectId).ToListAsync();
            ViewBag.ShipId = shipProjectId;
            ViewBag.NewsId = newsId;
            return View(items);
        }
    }
}
