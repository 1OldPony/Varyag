using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class AnythingElsesController : Controller
    {
        private readonly VaryagContext _context;
        private readonly IHostingEnvironment _Environment;

        public AnythingElsesController(VaryagContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _Environment = appEnvironment;
        }

        // GET: AnythingElses
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnythingElse.ToListAsync());
        }

        // GET: AnythingElses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnythingElses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FotoPath1,FotoPath2,ShortDescription,Description,PathToGallery")] AnythingElse anythingElse, IFormFile frontFoto1, IFormFile frontFoto2, IFormFileCollection galleryFoto)
        {
            await SaveImgAsync("frontFoto1.jpg", anythingElse.Name, frontFoto1);
            await SaveImgAsync("frontFoto2.jpg", anythingElse.Name, frontFoto2);
            await SaveImgToGalleryAsync(anythingElse.Name, galleryFoto);
            
            if (ModelState.IsValid)
            {
                anythingElse.FotoPath1= LittleHelper.PathAdapter(Path.Combine(_Environment.WebRootPath, "images", "projects", anythingElse.Name, "frontFoto1.jpg"), "frontFoto");
                anythingElse.FotoPath2 = LittleHelper.PathAdapter(Path.Combine(_Environment.WebRootPath, "images", "projects", anythingElse.Name, "frontFoto2.jpg"), "frontFoto");
                anythingElse.PathToGallery = Path.Combine(_Environment.WebRootPath, "images", "projects", anythingElse.Name, "gallery");

                _context.Add(anythingElse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anythingElse);
        }

        private async Task SaveImgAsync(string fotoName, string projectName, IFormFile anythingElseFoto)
        {
            string path = Path.Combine(_Environment.WebRootPath, "images", "projects");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(_Environment.WebRootPath, "images", "projects", projectName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var fileStream = new FileStream(path + "/" + fotoName, FileMode.Create))
            {
                await anythingElseFoto.CopyToAsync(fileStream);
            }
        }

        private async Task SaveImgToGalleryAsync (string projectName, IFormFileCollection anythingElseFotoCollection)
        {
            string path = Path.Combine(_Environment.WebRootPath, "images", "projects");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(_Environment.WebRootPath, "images", "projects", projectName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(_Environment.WebRootPath, "images", "projects", projectName, "gallery");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            for (int i = 0; i <= (anythingElseFotoCollection.Count() - 1); i++)
            {
                string fotoName = "ВерфьВаряг" + "(" + (i + 1).ToString() + ")" + ".jpg";

                using (var fileStream = new FileStream(path + "/" + fotoName, FileMode.Create))
                {
                    await anythingElseFotoCollection[i].CopyToAsync(fileStream);
                }
            }
        }


        // GET: AnythingElses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anythingElse = await _context.AnythingElse.FindAsync(id);
            if (anythingElse == null)
            {
                return NotFound();
            }
            return View(anythingElse);
        }

        // POST: AnythingElses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FotoPath1,FotoPath2,ShortDescription,Description,PathToGallery")] AnythingElse anythingElse, IFormFile frontFoto1, IFormFile frontFoto2, IFormFileCollection galleryFoto)
        {
            if (id != anythingElse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (frontFoto1!=null)
                    {
                        await SaveImgAsync("frontFoto1.jpg", anythingElse.Name, frontFoto1);
                    }

                    if (frontFoto2 != null)
                    {
                        await SaveImgAsync("frontFoto2.jpg", anythingElse.Name, frontFoto2);
                    }

                    if (galleryFoto != null)
                    {
                        await SaveImgToGalleryAsync(anythingElse.Name, galleryFoto);
                    }

                    anythingElse.FotoPath1 = LittleHelper.PathAdapter(Path.Combine(_Environment.WebRootPath, "images", "projects", anythingElse.Name, "frontFoto1.jpg"), "frontFoto");
                    anythingElse.FotoPath2 = LittleHelper.PathAdapter(Path.Combine(_Environment.WebRootPath, "images", "projects", anythingElse.Name, "frontFoto2.jpg"), "frontFoto");
                    anythingElse.PathToGallery = Path.Combine(_Environment.WebRootPath, "images", "projects", anythingElse.Name, "gallery");

                    _context.Update(anythingElse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnythingElseExists(anythingElse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(anythingElse);
        }

        // GET: AnythingElses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anythingElse = await _context.AnythingElse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anythingElse == null)
            {
                return NotFound();
            }

            return View(anythingElse);
        }

        // POST: AnythingElses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anythingElse = await _context.AnythingElse.FindAsync(id);

            LittleHelper.DeleteFiles(Path.Combine(_Environment.WebRootPath, "images", "projects", anythingElse.Name, "gallery"), true);
            LittleHelper.DeleteFiles(Path.Combine(_Environment.WebRootPath, "images", "projects", anythingElse.Name), true);

            _context.AnythingElse.Remove(anythingElse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnythingElseExists(int id)
        {
            return _context.AnythingElse.Any(e => e.Id == id);
        }
    }
}
