using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class CatalogController : Controller
    {
        private readonly VaryagContext _context;

        public CatalogController(VaryagContext context)
        {
            _context = context;
        }

        public IActionResult Sailboats()
        {
            ViewBag.TopPic = "sailboats";
            return View();
        }

        public async Task<IActionResult> ProjectDetails(int? id)
        {

            ViewBag.TopPic = "details";

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}