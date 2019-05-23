using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Varyag.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Sailboats()
        {
            return View();
        }
    }
}