using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Varyag.Models;

namespace Varyag.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProjectFotoViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public ProjectFotoViewComponent(VaryagContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? shipProjectId, int? newsId)
        {
            List<Foto> items = new List<Foto>();

            if (shipProjectId != null)
            {
                items = await db.Foto.Where(w => w.ShipProjectID == shipProjectId).ToListAsync();
                ViewBag.ShipId = shipProjectId;
            }
            else if (newsId != null)
            {
                items = await db.Foto.Where(w => w.NewsID == newsId).ToListAsync();
                ViewBag.NewsId = newsId;
            }


            return View(items);
        }
    }
}
