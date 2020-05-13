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
        public async Task<IActionResult> Index(int? page)
        {
            List<News> allNews = await _context.News.ToListAsync();

            if (allNews.Count >= 10)
            {
                if (page == null)
                {
                    page = 0;
                    ViewBag.CurrentPage = 1;
                }
                else
                {
                    page--;
                    if (page == 0)
                        ViewBag.CurrentPage = 1;
                    else
                        ViewBag.CurrentPage = page + 1;
                }

                if (allNews.Count % 10 == 0)
                {
                    ViewBag.Pages = allNews.Count / 10;
                    allNews = allNews.GetRange(page.Value * 10, 10);
                }
                else if (page == 0)
                {
                    ViewBag.Pages = (allNews.Count / 10) + 1;
                    allNews = allNews.GetRange(page.Value * 10, 10);
                }
                else
                {
                    ViewBag.Pages = (allNews.Count / 10) + 1;
                    if (ViewBag.CurrentPage != ViewBag.Pages)
                    {
                        allNews = allNews.GetRange(page.Value * 10, 10);
                    }
                    else
                    {
                        allNews = allNews.GetRange(page.Value * 10, allNews.Count % 10);
                    }
                }
            }
            else
                allNews = allNews.GetRange(0, allNews.Count);

            return View(LittleHelper.NewsToSortedViewModel(allNews));
        }

        [HttpPost]
        public async Task<IActionResult> SaveTempFoto(IFormFile newsFoto, string actionType,
            string fotoType, string shortFotoScale, string shortFotoX, string shortFotoY,
            string shortStory, string middleFotoScale, string middleFotoX, string middleFotoY,
            string middleStory, string wideFotoScale, string wideFotoX, string wideFotoY,
            string wideStory, int? newId, string newsDate, string oldNewsDate, 
            string keyWordRefresh, string newsDateRefresh)
        {
            string[] names = new string[] { "short.jpg", "middle.jpg", "wide.jpg" };
            if (newsFoto != null)
            {
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
                    wStory = wideStory,
                    keyWordR = keyWordRefresh,
                    newsDateR = newsDateRefresh
                });
            }
            else
            {
                string pathTemp = Path.Combine(_Environment.WebRootPath, "images", "temp");
                string pathForFinalTemp = Path.Combine(_Environment.WebRootPath, "images", "news", newsDate);

                string pathFrom = "", pathTo = "";

                switch (fotoType)
                {
                    case "общая":
                        for (int i = 0; i < names.Length; i++)
                        {
                            pathFrom = Path.Combine(pathTemp, names[i]);
                            pathTo = Path.Combine(pathForFinalTemp, names[i]);
                            LittleHelper.MoveTo(pathFrom, pathTo);
                        }
                        break;
                    case "мелкая":
                        pathFrom = Path.Combine(pathTemp, names[0]);
                        pathTo = Path.Combine(pathForFinalTemp, names[0]);
                        LittleHelper.MoveTo(pathFrom, pathTo);
                        break;
                    case "средняя":
                        pathFrom = Path.Combine(pathTemp, names[1]);
                        pathTo = Path.Combine(pathForFinalTemp, names[1]);
                        LittleHelper.MoveTo(pathFrom, pathTo);
                        break;
                    case "широкая":
                        pathFrom = Path.Combine(pathTemp, names[2]);
                        pathTo = Path.Combine(pathForFinalTemp, names[2]);
                        LittleHelper.MoveTo(pathFrom, pathTo);
                        break;
                    default:
                        break;
                }
                return RedirectToAction("Edit", new {
                    id = newId,
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
                    wStory = wideStory,
                    keyWordR = keyWordRefresh,
                    newsDateR = newsDateRefresh
                });
            }
        }

        private async Task SaveImgAsync(string name, IFormFile newsFoto)
        {

            string path = Path.Combine(_Environment.WebRootPath, "images", "temp");
            LittleHelper.DirectoryExistCheck(path);

            using (var fileStream = new FileStream(path + "/" + name, FileMode.Create))
            {
                await newsFoto.CopyToAsync(fileStream);
            }
        }


        // GET: News/Create
        public IActionResult Create(string shortScale, string shortX,
            string shortY, string shStory, string midScale, string midX,
            string midY, string midStory, string wideScale, string wideX,
            string wideY, string wStory, string keyWordR, string newsDateR)
        {
            ViewBag.RefreshEditor = new EditorModel()
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
                wideStory = wStory,
                keyWordRefresh = keyWordR,
                newsDateRefresh = newsDateR
            };

            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,Header,NewsDate,MainStory,KeyWord,PathToGallery,ShortImgScale,ShortImgX,ShortImgY," +
            "MiddleImgScale,MiddleImgX,MiddleImgY,WideImgScale,WideImgX,WideImgY,ShortStory,MiddleStory,WideStory,ShortFotoPreview,MiddleFotoPreview,WideSFotoPreview,PathToVideo1,PathToVideo2,PathToVideo3")] News news, IFormFileCollection newsGallery)
        {
            if (ModelState.IsValid)
            {
                string pathTemp = Path.Combine(_Environment.WebRootPath, "images", "temp");
                string pathForFinalTemp = Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate);
                string pathFinal = Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, news.NewsDate);
                string shortPreview = "", middlePreview = "", widePreview = "";

                LittleHelper.DirectoryExistCheck(pathFinal);

                string[] fotos = new string[] { "short.jpg", "middle.jpg", "wide.jpg" };

                foreach (var foto in fotos)
                {
                    string pathStart = Path.Combine(pathTemp, foto);
                    string pathEnd = Path.Combine(pathForFinalTemp, foto);

                    System.IO.File.Move(pathStart, pathEnd);

                    switch (foto)
                    {
                        case "short.jpg":
                            shortPreview = LittleHelper.PathAdapter(pathEnd, "preview");
                            break;
                        case "middle.jpg":
                            middlePreview = LittleHelper.PathAdapter(pathEnd, "preview");
                            break;
                        case "wide.jpg":
                            widePreview = LittleHelper.PathAdapter(pathEnd, "preview");
                            break;
                        default:
                            break;
                    }
                }

                for (int i = 0; i <= (newsGallery.Count() - 1); i++)
                {
                    string name = "ВерфьВаряг" + "(" + (i + 1).ToString() + ")" + news.NewsDate + ".jpg";

                    using (var fileStream = new FileStream(pathFinal + "/" + name, FileMode.Create))
                    {
                        await newsGallery[i].CopyToAsync(fileStream);
                    }
                }

                news.PathToGallery = pathFinal;
                news.ShortFotoPreview = shortPreview;
                news.MiddleFotoPreview = middlePreview;
                news.WideFotoPreview = widePreview;
                news.ShortImgScale = news.ShortImgScale + "%";
                news.ShortImgX = news.ShortImgX + "%";
                news.ShortImgY = news.ShortImgY + "%";
                news.MiddleImgScale = news.MiddleImgScale + "%";
                news.MiddleImgX = news.MiddleImgX + "%";
                news.MiddleImgY = news.MiddleImgY + "%";
                news.WideImgScale = news.WideImgScale + "%";
                news.WideImgX = news.WideImgX + "%";
                news.WideImgY = news.WideImgY + "%";

                if (news.PathToVideo1!=null)
                {
                    news.PathToVideo1 = LittleHelper.UrlGiver(news.PathToVideo1);
                }
                if (news.PathToVideo2!=null)
                {
                    news.PathToVideo2 = LittleHelper.UrlGiver(news.PathToVideo2);
                }
                if (news.PathToVideo3!=null)
                {
                    news.PathToVideo3 = LittleHelper.UrlGiver(news.PathToVideo3);
                }

                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id, string shStory, string midStory, string wStory, 
            string shortScale, string shortX, string shortY, string midScale, string midX, 
            string midY, string wideScale, string wideX, string wideY, string keyWordR, string newsDateR)
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

            news.ShortFotoPreview = "../"+news.ShortFotoPreview;
            news.MiddleFotoPreview = "../" + news.MiddleFotoPreview;
            news.WideFotoPreview = "../" + news.WideFotoPreview;

            ViewBag.RefreshEditor = new EditorModel()
            {
                shortFotoX = shortX,
                shortFotoY = shortY,
                shortFotoScale = shortScale,
                middleFotoX = midX,
                middleFotoY = midY,
                middleFotoScale = midScale,
                wideFotoX = wideX,
                wideFotoY = wideY,
                wideFotoScale = wideScale,
                keyWordRefresh = keyWordR,
                newsDateRefresh = newsDateR
            };

            ViewBag.ShortImgX = LittleHelper.PercentToCoordinates(news.ShortImgX);
            ViewBag.ShortImgY = LittleHelper.PercentToCoordinates(news.ShortImgY);
            ViewBag.ShortImgScale = LittleHelper.PercentToCoordinates(news.ShortImgScale);
            ViewBag.ShortStory = shStory;
            ViewBag.MiddleImgX = LittleHelper.PercentToCoordinates(news.MiddleImgX);
            ViewBag.MiddleImgY = LittleHelper.PercentToCoordinates(news.MiddleImgY);
            ViewBag.MiddleImgScale = LittleHelper.PercentToCoordinates(news.MiddleImgScale);
            ViewBag.MiddleStory = midStory;
            ViewBag.WideImgX = LittleHelper.PercentToCoordinates(news.WideImgX);
            ViewBag.WideImgY = LittleHelper.PercentToCoordinates(news.WideImgY);
            ViewBag.WideImgScale = LittleHelper.PercentToCoordinates(news.WideImgScale);
            ViewBag.WideStory = wStory;
            ViewBag.OldNewsDate = news.NewsDate;

            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, News news, IFormFileCollection newsGallery, string oldNewsDate)
        {
            if (id != news.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    news.ShortImgScale = news.ShortImgScale + "%";
                    news.ShortImgX = news.ShortImgX + "%";
                    news.ShortImgY = news.ShortImgY + "%";
                    news.MiddleImgScale = news.MiddleImgScale + "%";
                    news.MiddleImgX = news.MiddleImgX + "%";
                    news.MiddleImgY = news.MiddleImgY + "%";
                    news.WideImgScale = news.WideImgScale + "%";
                    news.WideImgX = news.WideImgX + "%";
                    news.WideImgY = news.WideImgY + "%";

                    if (news.NewsDate != oldNewsDate)
                    {
                        news.PathToGallery = Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, news.NewsDate);
                        news.ShortFotoPreview = LittleHelper.PathAdapter(Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, "short.jpg"), "preview");
                        news.MiddleFotoPreview = LittleHelper.PathAdapter(Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, "middle.jpg"), "preview");
                        news.WideFotoPreview = LittleHelper.PathAdapter(Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, "wide.jpg"), "preview");

                        Directory.Move(Path.Combine(_Environment.WebRootPath, "images", "news", oldNewsDate), Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate));
                        Directory.Move(Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, oldNewsDate), Path.Combine(_Environment.WebRootPath, "images", "news", news.NewsDate, news.NewsDate));
                    }

                    if (newsGallery.Count != 0)
                    {
                        LittleHelper.DeleteFiles(news.PathToGallery,false);

                        for (int i = 0; i <= (newsGallery.Count() - 1); i++)
                        {
                            string name = "ВерфьВаряг" + "(" + (i + 1).ToString() + ")" + news.NewsDate + ".jpg";

                            using (var fileStream = new FileStream(news.PathToGallery + "/" + name, FileMode.Create))
                            {
                                await newsGallery[i].CopyToAsync(fileStream);
                            }
                        }
                    }

                    if (news.PathToVideo1 != null)
                    {
                        news.PathToVideo1 = LittleHelper.UrlGiver(news.PathToVideo1);
                    }
                    if (news.PathToVideo2 != null)
                    {
                        news.PathToVideo2 = LittleHelper.UrlGiver(news.PathToVideo2);
                    }
                    if (news.PathToVideo3 != null)
                    {
                        news.PathToVideo3 = LittleHelper.UrlGiver(news.PathToVideo3);
                    }

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

            LittleHelper.DeleteFiles(news.PathToGallery,true);

            string[] pathParts = news.PathToGallery.Split(new char[] { '\\' });
            string pathTempFiles = "";
            for (int i = 0; i < (pathParts.Count() - 1); i++)
            {
                if (i==0)
                    pathTempFiles = pathTempFiles + pathParts[i];
                else
                    pathTempFiles = pathTempFiles + "/" + pathParts[i];
            }

            LittleHelper.DeleteFiles(pathTempFiles,true);

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
