using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Instructor, Student")]
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
        [Authorize(Roles = "Instructor")]
        public IActionResult Create()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Instructors = _context.Instructors.ToList();
            ViewBag.Vehicles = _context.Vehicles.ToList();

            return View();
        }

        // POST: DrivingLessons/Create
        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public IActionResult Create(DrivingLesson lesson)
        {
            _context.DrivingLessons.Add(lesson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: DrivingLessons/Edit/5
        [Authorize(Roles = "Instructor")]
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
        [Authorize(Roles = "Instructor")]
        public IActionResult Edit(DrivingLesson lesson)
        {
            _context.DrivingLessons.Update(lesson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: DrivingLessons/Delete/5
        [Authorize(Roles = "Instructor")]
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
        [Authorize(Roles = "Instructor")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var lesson = _context.DrivingLessons.Find(id);
            _context.DrivingLessons.Remove(lesson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Instructor, Student")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var drivingLesson = await _context.DrivingLessons.Include(l => l.Student).Include(l => l.Instructor).Include(l => l.Vehicle).FirstOrDefaultAsync(l => l.Id == id);

            if (drivingLesson == null) return NotFound();

            return View(drivingLesson);
        }

        public IActionResult GradesReport()
        {
            var data = _context.DrivingLessons.Where(l => l.Grade.HasValue).Include(l => l.Student).AsEnumerable().GroupBy(l => l.Student).Select(g => new StudentGradesViewModel
            {
                StudentName = $"{g.Key.Surname} {g.Key.Name}",
                Grades = g.Select(x => x.Grade.Value).ToList(),
                AverageGrade = g.Average(x => x.Grade.Value)
            }).ToList();

            return View(data);
        }
    }
}