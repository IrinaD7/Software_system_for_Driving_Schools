using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Create()
        {
            ViewBag.StudyPrograms = _context.StudyPrograms.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudyGroup group)
        {
            if (ModelState.IsValid)
            {
                _context.StudyGroups.Add(group);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.StudyPrograms = _context.StudyPrograms.ToList();
            return View(group);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var group = _context.StudyGroups
                                .Include(g => g.StudyProgram)
                                .FirstOrDefault(g => g.Id == id);
            if (group == null) return NotFound();

            ViewBag.StudyPrograms = _context.StudyPrograms.ToList();

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StudyGroup group)
        {
            if (id != group.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(group);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StudyPrograms = _context.StudyPrograms.ToList();
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
