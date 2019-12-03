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
            List<News> baseList = await _context.News.ToListAsync();
            List<News> operateList = new List<News>();
            foreach (var item in baseList)
            {
                string[] shPathParts = item.ShortFotoPreview.Split(new char[] { '\\' });
                string[] midPathParts = item.MiddleFotoPreview.Split(new char[] { '\\' });
                string[] widePathParts = item.WideFotoPreview.Split(new char[] { '\\' });

                operateList.Add(new News { Header=item.Header, KeyWord=item.KeyWord, MainStory=item.MainStory, NewsId=item.NewsId,
                 NewsDate=item.NewsDate, PathToGallery=item.PathToGallery, ShortStory=item.ShortStory, ShortImgY=item.ShortImgY,
                 ShortImgX=item.ShortImgX, ShortImgScale=item.ShortImgScale, ShortFotoPreview=pathAdapter(shPathParts), MiddleStory=item.MiddleStory,
                 MiddleImgX=item.MiddleImgX, MiddleImgY=item.MiddleImgY, MiddleImgScale=item.MiddleImgScale, MiddleFotoPreview=pathAdapter(midPathParts),
                 WideStory=item.WideStory, WideImgX=item.WideImgX, WideImgY=item.WideImgY, WideImgScale=item.WideImgScale, WideFotoPreview=pathAdapter(widePathParts)});
            }

            return View(operateList);
        }

        private string pathAdapter(string[]pathParts)
        {
            string fotoPath = "~/" + pathParts[(pathParts.Length - 1) - 3] + "/" + pathParts[(pathParts.Length - 1) - 2] + "/"
                + pathParts[(pathParts.Length - 1) - 1] + "/" + pathParts[(pathParts.Length - 1)];
            return fotoPath;
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
        public async Task<IActionResult> SaveTempFoto(IFormFile newsFoto, string actionType,
            string fotoType, string shortFotoScale, string shortFotoX, string shortFotoY,
            string shortStory, string middleFotoScale, string middleFotoX, string middleFotoY,
            string middleStory, string wideFotoScale, string wideFotoX, string wideFotoY,
            string wideStory, int? newId)
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

            if (actionType == "create")
            {
                return RedirectToAction("Create", new
                {
                    shortScale = shortFotoScale,
                    shortX = shortFotoX,
                    shortY = shortFotoY,
                    shStory = shortStory,
                    midScale = middleFotoScale,
                    midX = middleFotoX,
                    midY = middleFotoY,
                    midStory = middleStory,
                    wideScale = wideFotoScale,
                    wideX = wideFotoX,
                    wideY = wideFotoY,
                    wStory = wideStory
                });
            }
            else
            {
                return RedirectToAction("Edit", new { id = newId });
            }
        }

        private async Task SaveImgAsync(string name, IFormFile newsFoto) {

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
            "MiddleImgScale,MiddleImgX,MiddleImgY,WideImgScale,WideImgX,WideImgY,ShortStory,MiddleStory,WideStory,ShortFotoPreview,MiddleFotoPreview,WideSFotoPreview")] News news, IFormFileCollection newsGallery)
        {
            if (ModelState.IsValid)
            {
                string n = news.NewsDate;
                string pathTemp = Path.Combine(_Environment.WebRootPath, "images", "temp");
                string pathForFinalTemp = Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate);
                string pathFinal = Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, news.NewsDate);
                string shortPreview = "", middlePreview = "", widePreview = "";



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
                    switch (foto)
                    {
                        case "short.jpg":
                            shortPreview = pathEnd;
                            break;
                        case "middle.jpg":
                            middlePreview = pathEnd;
                            break;
                        case "wide.jpg":
                            widePreview = pathEnd;
                            break;
                        default:
                            break;
                    }
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
                news.ShortFotoPreview = shortPreview;
                news.MiddleFotoPreview = middlePreview;
                news.WideFotoPreview = widePreview;

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
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,Header,NewsDate,MainStory,KeyWord,PathToGallery,ShortImgScale,ShortImgX,ShortImgY," +
            "MiddleImgScale,MiddleImgX,MiddleImgY,WideImgScale,WideImgX,WideImgY,ShortStory,MiddleStory,WideStory,ShortFotoPreview,MiddleFotoPreview,WideSFotoPreview")] News news)
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

            DeleteFiles(news.PathToGallery);

            string[] pathParts = news.PathToGallery.Split(new char[] { '\\' });
            string pathTempFiles = "";
            for (int i = 0; i < (pathParts.Count() - 1); i++)
            {
                if (i==0)
                    pathTempFiles = pathTempFiles + pathParts[i];
                else
                    pathTempFiles = pathTempFiles + "/" + pathParts[i];
            }

            DeleteFiles(pathTempFiles);

            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void DeleteFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                FileInfo foto = new FileInfo(file);
                foto.Delete();
            }
            Directory.Delete(path);
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
