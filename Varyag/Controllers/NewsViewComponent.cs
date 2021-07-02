using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class NewsViewComponent : ViewComponent
    {
        private readonly VaryagContext db;
        private readonly ILogger _logger;

        public NewsViewComponent(VaryagContext context, ILoggerFactory loggerFactory)
        {
            db = context;
            _logger = loggerFactory.CreateLogger("FileLogger");
            LittleHelper.DirectoryExistCheck(Path.Combine(Directory.GetCurrentDirectory(), "ForLogggs"));
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "ForLogggs", "log" + DateTime.Today.ToShortDateString() + ".txt"));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<NewsViewModel> lastNews = new List<NewsViewModel>();
            //try
            //{
                List<News> news = await db.News.ToListAsync();
                List<NewsViewModel> sortedNews = LittleHelper.NewsToSortedViewModel(news);
                lastNews = sortedNews.AsEnumerable().Take(3).ToList();
            //}
            //catch (Exception e)
            //{
            //    _logger.LogInformation("ОШИБКА!!!! ВРЕМЯ {0}, СООБЩЕНИЕ {1}, МЕТОД {2}, ПУТЬ_ДО {3},", DateTime.Now.ToShortTimeString(), e.Message, e.TargetSite, e.StackTrace);
            //    throw new Exception("Не удалось загрузить новостные превью");
            //}

            return View(lastNews);
        }
    }
}