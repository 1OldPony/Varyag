using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public IActionResult AboutUs()
        {
            ViewData["Title"] = "Верфь деревянного судостроения Варяг";
            ViewData["Keywords"] = "Верфь Варяг, О верфи Варяг, Построить деревянный корабль, Купить деревянную лодку";
            ViewData["Description"] = "Верфь деревянного судостроения Варяг сециализируется на проектировании судов, шлюпок и лодок. Мы в строю уже 30 лет и можем предложить широкий выбор разнообразных проектов, построенных на нашей верфи или разработать новый.";
            return View();
        }

        public async Task<IActionResult> AllNews(string newsType, int? page, string direction, string part)
        {
            ViewData["Title"] = "Новости верфи деревянного судостроения Варяг";
            ViewData["Keywords"] = "СМИ о верфи Варяг, Новые суда построенные на верфи Варяг, Жизнь судов построенных на верфи Варяг";
            ViewData["Description"] = "Новости верфи деревянного судостроения Варяг";

            List<News> news = new List<News>();
            news = await _context.News.ToListAsync();

            int currentYear = DateTime.Today.Year, lastYear = currentYear, date = 0;

            foreach (var item in news)
            {
                date = int.Parse(item.NewsDate.Substring(item.NewsDate.Length - 4));
                if (date < lastYear)
                {
                    lastYear = date;
                }
            };
            ViewBag.actualNews = currentYear.ToString() + " - " + (currentYear - 1).ToString();
            ViewBag.recentNews = (currentYear - 2).ToString() + " - " + (currentYear - 4).ToString();
            ViewBag.oldNews = (currentYear - 5).ToString() + " - " + lastYear;

            switch (newsType)
            {
                case "smi":
                    news = news.Where(n => n.KeyWord.ToString() == "СМИ").ToList();
                    break;
                case "life":
                    news = news.Where(n => n.KeyWord.ToString() == "Жизнь_кораблей").ToList();
                    break;
                case "newShips":
                    news = news.Where(n => n.KeyWord.ToString() == "Новые_корабли").ToList();
                    break;
                default:
                    switch (part)
                    {
                        case "old":
                            news = news.Where(n => int.Parse(n.NewsDate.Substring(n.NewsDate.Length - 4)) <= currentYear - 5).ToList();
                            break;
                        case "recent":
                            news = news.Where(n => int.Parse(n.NewsDate.Substring(n.NewsDate.Length - 4)) <= currentYear - 3/*2 по настоящему*/ && int.Parse(n.NewsDate.Substring(n.NewsDate.Length - 4)) >= currentYear - 4).ToList();
                            break;
                        case "new":
                            news = news.Where(n => int.Parse(n.NewsDate.Substring(n.NewsDate.Length - 4)) >= currentYear - 2/*1 по настоящему*/).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
            }

            if (news.Count > 10)
            {
                //Устанавливаем значения номера страницы для поля навигации и для расчета диапазона загружаемых новостей
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

                //Расчитываем диапазон загружаемых новостей

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
                    if (ViewBag.CurrentPage != ViewBag.Pages)
                    {
                        news = news.GetRange(page.Value * 10, 10);
                    }
                    else
                    {
                        news = news.GetRange(page.Value * 10, news.Count % 10);
                    }
                }
            }
            else
                news = news.GetRange(0, news.Count);
            ViewBag.part = part;
            ViewBag.newsType = newsType;
            List<NewsViewModel> x = LittleHelper.NewsToSortedViewModel(news);

            return View(x);
        }

        public async Task<IActionResult> NewsDetails(int? id, string actualNews, string recentNews, string oldNews)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.actualNews = actualNews;
            ViewBag.recentNews = recentNews;
            ViewBag.oldNews = oldNews;

            //List<News> news = new List<News>();
            //news = await _context.News.ToListAsync();
            //List<NewsViewModel> sortedNews = LittleHelper.NewsToSortedViewModel(news);
            //List<NewsViewModel> newsLeftMenu = new List<NewsViewModel>();
            //newsLeftMenu.Add(sortedNews.FirstOrDefault(n => n.NewsId == id));

            //for (int i = 0; i < 6; i++)
            //{
            //    if (sortedNews.ElementAt(i).NewsId!= id)
            //    {
            //        newsLeftMenu.Add(sortedNews.ElementAt(i));
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}

            var news = await _context.News.Where(m => m.NewsId == id).SingleAsync();
            if (news == null)
            {
                return NotFound();
            }
            //List<News> newsMultiply = new List<News>();


            return View(news);
        }
        public async Task<IActionResult> AllArticles(string actualNews, string recentNews, string oldNews, string type)
        {
            List<Article> articles = new List<Article>();
            if (type == "Заказы для кино")
            {
                articles = await _context.Article.Where(a => a.ArticleType == "Заказы для кино").ToListAsync();
            }
            else if(type == "Заказы для музеев")
            {
                articles = await _context.Article.Where(a => a.ArticleType == "Заказы для музеев").ToListAsync();
            }
            else
            {
                articles = await _context.Article.ToListAsync();
            }

            if (articles == null)
            {
                return NotFound();
            }
            ViewBag.actualNews = actualNews;
            ViewBag.recentNews = recentNews;
            ViewBag.oldNews = oldNews;
            ViewBag.type = type;
            return View(articles);
        }
        public async Task<IActionResult> ArticleDetails(string route, string actualNews, string recentNews, string oldNews)
        {
            if (route == null)
            {
                return NotFound();
            }

            ViewBag.actualNews = actualNews;
            ViewBag.recentNews = recentNews;
            ViewBag.oldNews = oldNews;
            var article = await _context.Article.Where(a => a.ArticleRoute == route).SingleAsync();

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }
    }
}