using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class ProjectNewsViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public ProjectNewsViewComponent(VaryagContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string projectName)
        {
            List<News> items = new List<News>();
            items = await db.News.ToListAsync();
            List<News> neededNews = new List<News>();
            foreach (var item in items)
            {
                if (item.LinkedProjectNames!=null)
                {
                    if (item.LinkedProjectNames.Contains(projectName))
                    {
                        neededNews.Add(item);
                    }
                }
            }
            return View(LittleHelper.NewsToSortedViewModel(neededNews));
        }
    }
}
