using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolApp.Controllers
{
    public class DrivingLessonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrivingLessonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DrivingLessons
        public IActionResult Index()
        {
            var lessons = _context.DrivingLessons
                .Include(l => l.Student)
                .Include(l => l.Instructor)
                .Include(l => l.Vehicle)
                .ToList();

            return View(lessons);
        }

        // GET: DrivingLessons/Create
        public IActionResult Create()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Instructors = _context.Instructors.ToList();
            ViewBag.Vehicles = _context.Vehicles.ToList();

            return View();
        }

        // POST: DrivingLessons/Create
        [HttpPost]
        public IActionResult Create(DrivingLesson lesson)
        {
            _context.DrivingLessons.Add(lesson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: DrivingLessons/Edit/5
        public IActionResult Edit(int id)
        {
            var lesson = _context.DrivingLessons.Find(id);

            ViewBag.Students = _context.Students.ToList();
            ViewBag.Instructors = _context.Instructors.ToList();
            ViewBag.Vehicles = _context.Vehicles.ToList();

            return View(lesson);
        }

        // POST: DrivingLessons/Edit/5
        [HttpPost]
        public IActionResult Edit(DrivingLesson lesson)
        {
            _context.DrivingLessons.Update(lesson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: DrivingLessons/Delete/5
        public IActionResult Delete(int id)
        {
            var lesson = _context.DrivingLessons
                .Include(l => l.Student)
                .Include(l => l.Instructor)
                .Include(l => l.Vehicle)
                .FirstOrDefault(l => l.Id == id);

            return View(lesson);
        }

        // POST: DrivingLessons/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var lesson = _context.DrivingLessons.Find(id);
            _context.DrivingLessons.Remove(lesson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}