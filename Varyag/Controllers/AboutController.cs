using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class AboutController : Controller
    {
        private readonly VaryagContext _context;

        public AboutController(VaryagContext context)
        {
            _context = context;
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("О_Нас/Наши_новости")]
        public async Task<IActionResult> AllNews(string newsType, int? page)
        {
            List<News> news = new List<News>();
            switch (newsType)
            {
                case "smi":
                    news = await _context.News.Where(n=>n.KeyWord.ToString() == "СМИ").ToListAsync();
                    break;
                case "life":
                    news = await _context.News.Where(n => n.KeyWord.ToString() == "Жизнь_кораблей").ToListAsync();
                    break;
                case "newShips":
                    news = await _context.News.Where(n => n.KeyWord.ToString() == "Новые_корабли").ToListAsync();
                    break;
                default:
                    news = await _context.News.ToListAsync();
                    break;
            }

            news = news.OrderBy(n=>n.NewsDate).ToList();

            if (news.Count >= 10)
            {
                if (page == null)
                    page = 0;
                else
                    page--;

                if (news.Count % 10 == 0)
                {
                    ViewBag.Pages = news.Count / 10;
                    news = news.GetRange(page.Value * 10, 10);
                }
                else if (page == 0)
                {
                    ViewBag.Pages = (news.Count / 10) + 1;
                    news = news.GetRange(page.Value * 10, 10);
                }
                else
                {
                    ViewBag.Pages = (news.Count / 10) + 1;
                    news = news.GetRange(page.Value * 10, news.Count % 10);
                }
            }
            else
                news = news.GetRange(0, news.Count);

            ViewBag.newsType = newsType;

            return View(news);
        }

        public async Task<IActionResult> NewsDetails(int? id)
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
    }
}