using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DrivingSchoolApp.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Instructors.Include(i => i.AssignedVehicle).ToList());

        public IActionResult Create()
        {
            ViewBag.Vehicles = new SelectList(_context.Vehicles, "Id", "Model");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Vehicles = new SelectList(_context.Vehicles, "Id", "Model", instructor.AssignedVehicleId);
            return View(instructor);
        }

        public IActionResult Edit(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor == null) return NotFound();
            ViewBag.Vehicles = new SelectList(_context.Vehicles, "Id", "Model", instructor.AssignedVehicleId);
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(instructor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Vehicles = new SelectList(_context.Vehicles, "Id", "Model", instructor.AssignedVehicleId);
            return View(instructor);
        }

        public IActionResult Delete(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = _context.Instructors.Find(id);
            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
