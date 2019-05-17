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
    public class ProjectsController : Controller
    {
        private readonly VaryagContext _context;

        public ProjectsController(VaryagContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProjectImageRender(int? id, string fot)
        {
            //Foto foto;
            var project = await _context.Project.SingleAsync(f => f.ProjectID == id);

            if (fot == "sheme")
            {
                byte[] image = project.ShipSheme;
                return File(image, "image/jpg");
            }
            else
            {
                byte[] image = project.MainFoto;
                return File(image, "image/jpg");
            }
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            //SelectList Types = _context.Project.Ty
            return View(await _context.Project.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel model/*[Bind("ProjectID,Name,Length,Windth,Deep,Volume,Mass,NumberOfOars,EnginePower,Speed,SailArea,SleepingAreas,PassengerCap,FuelCap,FreshWaterCap,Type,Description,CruiseShip,StudyShip,FishingShip,HistoricalShip,ReserchShip,PassangerShip")] Project project*/)
        {
            if (ModelState.IsValid)
            {
                var project = new Project
                {
                    CruiseShip = model.CruiseShip,
                    Deep = model.Deep,
                    Description = model.Description,
                    EnginePower = model.EnginePower,
                    FishingShip = model.FishingShip,
                    FreshWaterCap = model.FreshWaterCap,
                    FuelCap = model.FuelCap,
                    HistoricalShip = model.HistoricalShip,
                    Length = model.Length,
                    Mass = model.Mass,
                    Name = model.Name,
                    NumberOfOars = model.NumberOfOars,
                    PassangerShip = model.PassangerShip,
                    PassengerCap = model.PassengerCap,
                    ProjectID = model.ProjectID,
                    ReserchShip = model.ReserchShip,
                    SailArea = model.SailArea,
                    SleepingAreas = model.SleepingAreas,
                    Speed = model.Speed,
                    StudyShip = model.StudyShip,
                    Type = model.Type,
                    Volume = model.Volume,
                    Windth = model.Windth
                };
                using (var memoryStream = new MemoryStream())
                {
                    await model.ShipSheme.CopyToAsync(memoryStream);
                    project.ShipSheme = memoryStream.ToArray();
                }
                using (var memoryStream = new MemoryStream())
                {
                    await model.MainFoto.CopyToAsync(memoryStream);
                    project.MainFoto = memoryStream.ToArray();
                }
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectViewModel model)
        {
            if (id != model.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var project = new Project
                    {
                        CruiseShip = model.CruiseShip,
                        Deep = model.Deep,
                        Description = model.Description,
                        EnginePower = model.EnginePower,
                        FishingShip = model.FishingShip,
                        FreshWaterCap = model.FreshWaterCap,
                        FuelCap = model.FuelCap,
                        HistoricalShip = model.HistoricalShip,
                        Length = model.Length,
                        Mass = model.Mass,
                        Name = model.Name,
                        NumberOfOars = model.NumberOfOars,
                        PassangerShip = model.PassangerShip,
                        PassengerCap = model.PassengerCap,
                        ProjectID = model.ProjectID,
                        ReserchShip = model.ReserchShip,
                        SailArea = model.SailArea,
                        SleepingAreas = model.SleepingAreas,
                        Speed = model.Speed,
                        StudyShip = model.StudyShip,
                        Type = model.Type,
                        Volume = model.Volume,
                        Windth = model.Windth
                    };

                    if (model.ShipSheme != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.ShipSheme.CopyToAsync(memoryStream);
                            project.ShipSheme = memoryStream.ToArray();
                        }
                    }
                    if (model.MainFoto != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.MainFoto.CopyToAsync(memoryStream);
                            project.MainFoto = memoryStream.ToArray();
                        }
                    }
                    
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(model.ProjectID))
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
            return View(model);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectID == id);
        }
    }
}
