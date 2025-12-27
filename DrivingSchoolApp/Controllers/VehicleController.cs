using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace DrivingSchoolApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Vehicles.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public IActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Update(vehicle);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public IActionResult Delete(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
