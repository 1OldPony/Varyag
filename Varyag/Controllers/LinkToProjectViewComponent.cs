using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class LinkToProjectViewComponent : ViewComponent
    {
        private readonly VaryagContext db;

        public LinkToProjectViewComponent(VaryagContext context)
        {
            db = context;
        }

        //enum ProjectsNames { };

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Project> items = new List<Project>();
            items = await db.Project.ToListAsync();
            LittleHelper.ProjectsToSortedViewModel(items,true);

            MultiSelectList projectsNames = new MultiSelectList(LittleHelper.ProjectsToSortedViewModel(items, true), "Length", "Name");
            ViewData["projectNames"] = projectsNames;
            return View();
        }
    }
}