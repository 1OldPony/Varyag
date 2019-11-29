using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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

        public async Task<IViewComponentResult> InvokeAsync(int? shipProjectId, int? newsId)
        {
            if (shipProjectId != null)
            {
                var items = await db.Foto.Where(w => w.ShipProjectID == shipProjectId).ToListAsync();
                ViewBag.ShipId = shipProjectId;
                return View(items);
            }
            else
            {
                var items = await db.News.Where(i=>i.NewsId == newsId).SingleAsync();
                string[] fotos = Directory.GetFiles(items.PathToGallery);
                List<string> fotoPaths = new List<string>();
                foreach (var item in fotos)
                {
                    string[] pathParts = item.Split(new char[] { '\\' });
                    int x = pathParts.Count() - 1;
                    string path = "~/" + pathParts[x - 4] + "/" + pathParts[x - 3] + "/" + pathParts[x - 2] + "/" + pathParts[x - 1] + "/" + pathParts[x];
                    fotoPaths.Add(path);
                }
                return View("NewsGallery",fotoPaths);
            }
        }
    }
}