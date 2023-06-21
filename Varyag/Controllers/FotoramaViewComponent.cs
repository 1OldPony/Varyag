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

        public async Task<IViewComponentResult> InvokeAsync(int? shipProjectId, int? newsId, int? anythingId, int? articleId, string galleryPath, bool singleFoto)
        {
            if (shipProjectId != null)
            {
                var items = await db.Foto.Where(w => w.ShipProjectID == shipProjectId).ToListAsync();
                ViewBag.ShipId = shipProjectId;
                return View(items);
            }
            else if (newsId != null)
            {
                var news = await db.News.Where(i=>i.NewsId == newsId).SingleAsync();
                string[] fotos = Directory.GetFiles(news.PathToGallery);
                ViewBag.singleFoto = false;
                List<string> fotoPaths = new List<string>();
                foreach (var item in fotos)
                {
                    string path = LittleHelper.PathAdapter(item, "gallery");
                    fotoPaths.Add(path);
                }
                return View("NewsGallery",fotoPaths);
            }
            else if (articleId != null)
            {
                string[] fotos = Directory.GetFiles(galleryPath);
                ViewBag.singleFoto = singleFoto;
                List<string> fotoPaths = new List<string>();
                if (singleFoto)
                {
                    foreach (var item in fotos)
                    {
                        string path = LittleHelper.PathAdapter(item, "articlePreview");
                        fotoPaths.Add(path);
                    }
                }
                else
                {
                    foreach (var item in fotos)
                    {
                        string path = LittleHelper.PathAdapter(item, "gallery");
                        fotoPaths.Add(path);
                    }
                }
                return View("NewsGallery", fotoPaths);
            }
            else
            {
                var items = await db.AnythingElse.Where(i => i.Id == anythingId).SingleAsync();
                string[] fotos = Directory.GetFiles(items.PathToGallery);
                List<string> fotoPaths = new List<string>();
                foreach (var item in fotos)
                {
                    string path = LittleHelper.PathAdapter(item, "gallery");
                    fotoPaths.Add(path);
                }
                return View("NewsGallery", fotoPaths);
            }
        }
    }
}