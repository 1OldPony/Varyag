using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;
using Varyag.Models.ViewModels;

namespace Varyag.Controllers
{
    [Authorize(Roles = "admin")]
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
        public IActionResult Create(int? ShipProjectId, int? NewsId)
        {
            ViewBag.ShipId = ShipProjectId;
            ViewBag.NewsId = NewsId;
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
                return RedirectToAction("Index", "Projects");
            }
            return RedirectToAction(nameof(Create));
        }
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
            return RedirectToAction("Index", "Projects");
        }

        private bool FotoExists(int id)
        {
            return _context.Foto.Any(e => e.FotoID == id);
        }
    }
}
