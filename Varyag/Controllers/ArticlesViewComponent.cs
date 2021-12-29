using System;
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

            List<Article> AllArticles = articles.ToList();
            //List<Article> Articles = articles.Take(2).ToList();

            List<Article> Articles = new List<Article>();
            Random rand = new Random();
            int[] allNumbers = new int[2];
            int countOfNumbers = 0;
            while (countOfNumbers < 2)
            {
                int articleNumber = rand.Next(0, AllArticles.Count() - 1);
                if (!allNumbers.Contains(articleNumber))
                {
                    allNumbers[countOfNumbers] = articleNumber;
                    countOfNumbers++;
                }
            }

            foreach (var item in allNumbers)
            {
                Articles.Add(AllArticles.ElementAt(item));
            }

            return View(Articles);
        }
    }
}