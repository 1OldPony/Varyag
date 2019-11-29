using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;
using Varyag.Models.ViewModels;

namespace Varyag.Controllers
{
    public class NewsController : Controller
    {
        private readonly VaryagContext _context;
        private readonly IHostingEnvironment _Environment;

        public NewsController(VaryagContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _Environment = appEnvironment;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }


        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> SaveTempFoto(IFormFile newsFoto,
            string fotoType, string shortFotoScale, string shortFotoX, string shortFotoY,
            string shortStory, string middleFotoScale, string middleFotoX, string middleFotoY,
            string middleStory, string wideFotoScale, string wideFotoX, string wideFotoY,
            string wideStory)
        {
            if (newsFoto != null)
            {
                string[] names = new string[] { "short.jpg", "middle.jpg", "wide.jpg" };

                switch (fotoType)
                {
                    case "общая":
                        foreach (var item in names)
                        {
                            await SaveImgAsync(item, newsFoto);
                        }
                        break;
                    case "мелкая":
                        await SaveImgAsync(names[0], newsFoto);
                        break;
                    case "средняя":
                        await SaveImgAsync(names[1], newsFoto);
                        break;
                    case "широкая":
                        await SaveImgAsync(names[2], newsFoto);
                        break;
                    default:
                        break;
                }
            }

            return RedirectToAction("Create", new { shortScale = shortFotoScale,
                shortX = shortFotoX, shortY = shortFotoY, shStory = shortStory,
                midScale = middleFotoScale, midX = middleFotoX, midY = middleFotoY,
                midStory = middleStory, wideScale = wideFotoScale,
                wideX = wideFotoX, wideY = wideFotoY, wStory = wideStory
            });
        }

        public async Task SaveImgAsync(string name, IFormFile newsFoto) {

            string path = Path.Combine(_Environment.WebRootPath, "images", "temp");
            using (var fileStream = new FileStream(path + "/" + name, FileMode.Create))
            {
                await newsFoto.CopyToAsync(fileStream);
            }
        }

        // GET: News/Create
        public IActionResult Create(string shortScale, string shortX,
            string shortY, string shStory, string midScale, string midX,
            string midY, string midStory, string wideScale, string wideX,
            string wideY, string wStory)
        {
            ViewBag.Editor = new EditorModel()
            {
                shortFotoScale = shortScale,
                shortFotoX = shortX,
                shortFotoY = shortY,
                shortStory = shStory,
                middleFotoScale = midScale,
                middleFotoX = midX,
                middleFotoY = midY,
                middleStory = midStory,
                wideFotoScale = wideScale,
                wideFotoX = wideX,
                wideFotoY = wideY,
                wideStory = wStory

            };

            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,Header,NewsDate,MainStory,KeyWord,PathToGallery,ShortImgScale,ShortImgX,ShortImgY," +
            "MiddleImgScale,MiddleImgX,MiddleImgY,WideImgScale,WideImgX,WideImgY,ShortStory,MiddleStory,WideStory")] News news, IFormFileCollection newsGallery)
        {
            if (ModelState.IsValid)
            {
                string n = news.NewsDate;
                string pathTemp = Path.Combine(_Environment.WebRootPath, "images", "temp");
                string pathForFinalTemp = Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate);
                string pathFinal = Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, news.NewsDate);

                if (!Directory.Exists(pathFinal))
                {
                    Directory.CreateDirectory(pathFinal);
                }

                string[] fotos = new string[] { "short.jpg", "middle.jpg", "wide.jpg" };

                foreach (var foto in fotos)
                {
                    string pathStart = Path.Combine(pathTemp, foto);
                    string pathEnd = Path.Combine(pathForFinalTemp, foto);
                    FileInfo file = new FileInfo(pathStart);
                    file.MoveTo(pathEnd);
                }

                for (int i = 0; i <= (newsGallery.Count()-1); i++)
                {
                    string name = "ВерфьВаряг" + "(" + (i+1).ToString() + ")" + news.NewsDate + ".jpg";

                    using (var fileStream = new FileStream(pathFinal + "/" + name, FileMode.Create))
                    {
                        await newsGallery[i].CopyToAsync(fileStream);
                    }
                }

                news.PathToGallery = pathFinal;

                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,Header,ShortStory,MainStory,KeyWord,ShortImgPath,ShortImgScale,ShortImgX,ShortImgY,MiddleImgPath,MiddleImgScale,MiddleImgX,MiddleImgY,WideImgPath,WideImgScale,WideImgX,WideImgY")] News news)
        {
            if (id != news.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);

            string[] files = Directory.GetFiles(news.PathToGallery);
            foreach (var file in files)
            {
                FileInfo foto = new FileInfo(file);
                foto.Delete();
            }
            Directory.Delete(news.PathToGallery);


            //string[] fotos = Directory.GetFiles(news.PathToGallery);
            //List<string> fotoPaths = new List<string>();
            //foreach (var item in fotos)
            //{
            //    string[] pathParts = item.Split(new char[] { '\\' });
            //    int x = pathParts.Count() - 1;
            //    string path = "~/" + pathParts[x - 4] + pathParts[x - 3] + "/" + pathParts[x - 2] + "/" + pathParts[x - 1] + "/" + pathParts[x];
            //    fotoPaths.Add(path);
            //}


            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
