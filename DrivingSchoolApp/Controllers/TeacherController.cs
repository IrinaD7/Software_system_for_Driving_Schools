using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Teachers.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        public IActionResult Edit(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Update(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = _context.Teachers.Find(id);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
