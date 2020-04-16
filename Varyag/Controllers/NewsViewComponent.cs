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
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "ForLogggs", "log"+DateTime.Today+".txt"));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //List<NewsViewModel> lastNews = new List<NewsViewModel>();
            //try
            //{
                List<News> news = await db.News.ToListAsync();
                List<NewsViewModel> sortedNews = LittleHelper.NewsToSortedViewModel(news);
            List<NewsViewModel> lastNews = sortedNews.AsEnumerable().Take(3).ToList();
            //}
            //catch (ArgumentNullException e)
            //{
            //    _logger.LogInformation("Ошибка!!! Дата {0}, исключение {1}, источник {2}, след {3}", DateTime.Now, e.Message, e.TargetSite, e.StackTrace);
            //}
            return View(lastNews);
        }
    }
}