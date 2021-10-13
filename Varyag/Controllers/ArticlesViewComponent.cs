using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class ArticlesViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public ArticlesViewComponent(VaryagContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await db.Article.ToListAsync();

            List<Article> Articles = articles.Take(2).ToList();
            //lastNews = sortedNews.AsEnumerable().Take(2).ToList();

            return View(Articles);
        }
    }
}