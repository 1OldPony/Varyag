using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Varyag.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult AboutUs()
        {
            //ViewBag.TopPic = "sailboats";
            return View();
        }
    }
}