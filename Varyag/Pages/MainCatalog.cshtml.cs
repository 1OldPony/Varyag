using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Pages
{
    public class MainCatalogModel : PageModel
    {
        private readonly Varyag.Models.VaryagContext _context;

        public MainCatalogModel(Varyag.Models.VaryagContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync()
        {
            Project = await _context.Project.ToListAsync();
        }
    }
}
