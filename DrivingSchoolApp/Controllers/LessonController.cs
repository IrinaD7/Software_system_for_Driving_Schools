using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolApp.Controllers
{
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public IActionResult Index()
        {
            var lessons = _context.Lessons
                .Include(l => l.Teacher)
                .Include(l => l.Group)
                .ToList();

            return View(lessons);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Groups = _context.StudyGroups.ToList();
            return View();
        }

        // POST: Lessons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teachers = _context.Teachers.ToList();
                ViewBag.Groups = _context.StudyGroups.ToList();
                return View(lesson);
            }

            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Lessons/Edit/5
        public IActionResult Edit(int id)
        {
            var lesson = _context.Lessons.Find(id);
            if (lesson == null) return NotFound();
            ViewBag.Teachers = new SelectList(_context.Teachers.ToList(), "Id", "Surname", lesson.TeacherId);
            ViewBag.Groups = new SelectList(_context.StudyGroups.ToList(), "Id", "Name", lesson.GroupId);

            return View(lesson);
        }

        // POST: Lessons/Edit/5
        [HttpPost]
        public IActionResult Edit(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "Surname", lesson.TeacherId);
                ViewBag.Groups = new SelectList(_context.StudyGroups, "Id", "Name", lesson.GroupId);
                return View(lesson);
            }

            var existingLesson = _context.Lessons.Find(lesson.Id);
            if (existingLesson == null) return NotFound();
            existingLesson.TeacherId = lesson.TeacherId;
            existingLesson.GroupId = lesson.GroupId;
            existingLesson.Classroom = lesson.Classroom;
            existingLesson.Date = lesson.Date;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Lessons/Delete/5
        public IActionResult Delete(int id)
        {
            var lesson = _context.Lessons
                .Include(l => l.Teacher)
                .Include(l => l.Group)
                .FirstOrDefault(l => l.Id == id);

            if (lesson == null) return NotFound();
            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var lesson = _context.Lessons.Find(id);
            _context.Lessons.Remove(lesson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
