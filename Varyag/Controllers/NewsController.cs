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
            string fotoType, string shortFotoName, string shortFotoAlt, string shortFotoScale,
            string shortFotoX, string shortFotoY/*, string midFotoName, string midFotoAlt, string midFotoScale,*/
            /*string midFotoX, string midFotoY*/)
        {
            if (newsFoto != null)
            {
                string name;

                switch (fotoType)
                {
                    case "short":
                        name = "short.jpg";
                        break;
                    case "middle":
                        name = "medium.jpg";
                        break;
                    case "wide":
                        name = "wide.jpg";
                        break;
                    default:
                        name = "wide.jpg";
                        break;
                }

                string path = "/images/temp/" + name;

                using (var fileStream = new FileStream(_Environment.WebRootPath + path, FileMode.Create))
                {
                    await newsFoto.CopyToAsync(fileStream);
                }
            }
            return RedirectToAction("Create", new { shortName = shortFotoName,
                shortAlt = shortFotoAlt, shortScale = shortFotoScale,
                shortX = shortFotoX, shortY= shortFotoY
            });
        }


        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,Header,ShortStory,MainStory,KeyWord,ShortImgPath,ShortImgScale,ShortImgX,ShortImgY,MiddleImgPath," +
            "MiddleImgScale,MiddleImgX,MiddleImgY,WideImgPath,WideImgScale,WideImgX,WideImgY")] News news, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
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
