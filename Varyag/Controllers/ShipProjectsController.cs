using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;

namespace Varyag.Controllers
{
    public class ShipProjectsController : Controller
    {
        private readonly VaryagContext _context;

        public ShipProjectsController(VaryagContext context)
        {
            _context = context;
        }

        // GET: ShipProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShipProject.ToListAsync());
        }

        // GET: ShipProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipProject = await _context.ShipProject
                .FirstOrDefaultAsync(m => m.ShipProjectID == id);
            if (shipProject == null)
            {
                return NotFound();
            }

            return View(shipProject);
        }

        // GET: ShipProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShipProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipProjectID,ProjectName,ProjectLength,ProjectWindth,ProjectDeep,ProjectVolume,ProjectEnginePower,ProjectSpeed,ProjectSailArea,ProjectSleepingAreas,ProjectPassengerCap,ProjectFuelCap,ProjectFreshWaterCap,ProjectType,ProjectDescription,CruiseShip,StudyShip,FishingShip,HistoricalShip,ReserchShip,PassangerShip")] ShipProject shipProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipProject);
        }

        // GET: ShipProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipProject = await _context.ShipProject.FindAsync(id);
            if (shipProject == null)
            {
                return NotFound();
            }
            return View(shipProject);
        }

        // POST: ShipProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipProjectID,ProjectName,ProjectLength,ProjectWindth,ProjectDeep,ProjectVolume,ProjectEnginePower,ProjectSpeed,ProjectSailArea,ProjectSleepingAreas,ProjectPassengerCap,ProjectFuelCap,ProjectFreshWaterCap,ProjectType,ProjectDescription,CruiseShip,StudyShip,FishingShip,HistoricalShip,ReserchShip,PassangerShip")] ShipProject shipProject)
        {
            if (id != shipProject.ShipProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipProjectExists(shipProject.ShipProjectID))
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
            return View(shipProject);
        }

        // GET: ShipProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipProject = await _context.ShipProject
                .FirstOrDefaultAsync(m => m.ShipProjectID == id);
            if (shipProject == null)
            {
                return NotFound();
            }

            return View(shipProject);
        }

        // POST: ShipProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipProject = await _context.ShipProject.FindAsync(id);
            _context.ShipProject.Remove(shipProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipProjectExists(int id)
        {
            return _context.ShipProject.Any(e => e.ShipProjectID == id);
        }
    }
}
