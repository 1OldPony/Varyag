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

        public IActionResult Index()
        {
            ViewData["Title"] = "Верфь деревянного судостроения Варяг";
            ViewData["Keywords"] = "Верфь Варяг, О верфи Варяг, Построить деревянный корабль, Купить деревянную лодку";
            ViewData["Description"] = "Верфь деревянного судостроения Варяг сециализируется на проектировании судов, шлюпок и лодок. Мы в строю уже 30 лет и можем предложить широкий выбор разнообразных проектов, построенных на нашей верфи или разработать новый.";
            return View();
        }

        [Route("О_нас/О_нашей_верфи")]
        public IActionResult AboutUs()
        {
            ViewData["Title"] = "Верфь деревянного судостроения Варяг";
            ViewData["Keywords"] = "Верфь Варяг, О верфи Варяг, Построить деревянный корабль, Купить деревянную лодку";
            ViewData["Description"] = "Верфь деревянного судостроения Варяг сециализируется на проектировании судов, шлюпок и лодок. Мы в строю уже 30 лет и можем предложить широкий выбор разнообразных проектов, построенных на нашей верфи или разработать новый.";
            return View();
        }

        [Route("О_Нас/Наши_новости")]
        public async Task<IActionResult> AllNews(string newsType, int? page, string direction)
        {
            ViewData["Title"] = "Новости верфи деревянного судостроения Варяг";
            ViewData["Keywords"] = "СМИ о верфи Варяг, Новые суда построенные на верфи Варяг, Жизнь судов построенных на верфи Варяг";
            ViewData["Description"] = "Новости верфи деревянного судостроения Варяг";

            List<News> news = new List<News>();
            switch (newsType)
            {
                case "smi":
                    news = await _context.News.Where(n => n.KeyWord.ToString() == "СМИ").ToListAsync();
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

            if (news.Count >= 10)
            {
                switch (direction)
                {
                    case "left":
                        if (page == null || page == 1)
                        {
                            page = 0;
                            ViewBag.CurrentPage = 1;
                        }
                        else
                        {
                            page = page - 2;
                            if (page == 0)
                                ViewBag.CurrentPage = 1;
                            else
                                ViewBag.CurrentPage = page + 1;
                        }
                        break;
                    case "right":
                        if (page == news.Count / 10 && news.Count % 10 != 0)
                            ViewBag.CurrentPage = page + 1;
                        else if (page == (news.Count / 10) + 1)
                        {
                            page = (news.Count / 10);
                            ViewBag.CurrentPage = page + 1;
                        }
                        else
                        {
                            ViewBag.CurrentPage = page + 1;
                        }
                        break;
                    default:
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
                        break;
                }

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
            List<NewsViewModel> x = LittleHelper.NewsToSortedViewModel(news);

            return View(x);
        }

        [Route("О_Нас/Наши_новости/{id}")]
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