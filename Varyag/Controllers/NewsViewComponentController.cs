using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class NewsViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public NewsViewComponent(VaryagContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<News> news = await db.News.OrderByDescending(n=>n.NewsDate).Take(3).OrderByDescending(x => x.NewsDate).ToListAsync();
            return View(news);
        }
    }
}