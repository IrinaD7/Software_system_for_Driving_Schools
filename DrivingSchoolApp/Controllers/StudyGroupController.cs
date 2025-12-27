using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolApp.Controllers
{
    public class StudyGroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudyGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var groups = _context.StudyGroups.ToList();
            return View(groups);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudyGroup group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(group);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        public IActionResult Edit(int id)
        {
            var group = _context.StudyGroups.Find(id);
            if (group == null) return NotFound();
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudyGroup group)
        {
            if (ModelState.IsValid)
            {
                _context.Update(group);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        public IActionResult Delete(int id)
        {
            var group = _context.StudyGroups.Find(id);
            if (group == null) return NotFound();
            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var group = _context.StudyGroups.Find(id);
            _context.StudyGroups.Remove(group);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
