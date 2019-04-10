using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;
using Varyag.Models.ViewModels;

namespace Varyag.Controllers
{
    public class FotoesController : Controller
    {
        private readonly VaryagContext _context;

        public FotoesController(VaryagContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ImageRender(int? id)
        {
            //Foto foto;
            var foto = await _context.Foto.SingleAsync(f => f.FotoID.Equals(id));

            byte[] image = foto.ProjectFoto;
            return File(image, "image/jpg");
        }

        // GET: Fotoes
        public async Task<IActionResult> Index()
        {
            var varyagContext = _context.Foto.Include(f => f.News).Include(f => f.ShipProject);
            return View(await varyagContext.ToListAsync());
        }

        // GET: Fotoes/Create
        public IActionResult Create()
        {
            ViewData["NewsID"] = new SelectList(_context.Set<News>(), "NewsId", "Header");
            ViewData["ShipProjectID"] = new SelectList(_context.Project, "ProjectID", "Name");
            return View();
        }

        // POST: Fotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FotoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var foto = new Foto
                {
                    Name = model.Name,
                    Alt = model.Alt,
                    ShipProjectID = model.ShipProjectID,
                    NewsID = model.NewsID,
                    FotoID = model.FotoID
                };
                using (var memoryStream = new MemoryStream())
                {
                    await model.Foto.CopyToAsync(memoryStream);
                    foto.ProjectFoto = memoryStream.ToArray();
                }
                _context.Add(foto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }

        //// GET: Fotoes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var foto = await _context.Foto.FindAsync(id);
        //    if (foto == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["NewsID"] = new SelectList(_context.Set<News>(), "NewsId", "NewsId", foto.NewsID);
        //    ViewData["ShipProjectID"] = new SelectList(_context.Project, "ProjectID", "Description", foto.ShipProjectID);
        //    return View(foto);
        //}

        //// POST: Fotoes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("FotoID,Alt,Name,ProjectFoto,ShipProjectID,NewsID")] Foto foto)
        //{
        //    if (id != foto.FotoID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(foto);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FotoExists(foto.FotoID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["NewsID"] = new SelectList(_context.Set<News>(), "NewsId", "NewsId", foto.NewsID);
        //    ViewData["ShipProjectID"] = new SelectList(_context.Project, "ProjectID", "Description", foto.ShipProjectID);
        //    return View(foto);
    //}

        // GET: Fotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foto = await _context.Foto
                .Include(f => f.News)
                .Include(f => f.ShipProject)
                .FirstOrDefaultAsync(m => m.FotoID == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // POST: Fotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foto = await _context.Foto.FindAsync(id);
            _context.Foto.Remove(foto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoExists(int id)
        {
            return _context.Foto.Any(e => e.FotoID == id);
        }
    }
}
