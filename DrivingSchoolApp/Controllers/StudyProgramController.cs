using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrivingSchoolApp.Models;
using DrivingSchoolApp.Data;

namespace DrivingSchoolApp.Controllers
{
    public class StudyProgramController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudyProgramController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudyProgram
        public IActionResult Index()
        {
            var programs = _context.StudyPrograms.ToList();
            return View(programs);
        }

        // GET: StudyProgram/Create
        public IActionResult Create()
        {
            ViewBag.Categories = Enum.GetValues(typeof(Category));
            return View();
        }

        // POST: StudyProgram/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudyProgram program)
        {
            if (ModelState.IsValid)
            {
                _context.StudyPrograms.Add(program);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = Enum.GetValues(typeof(Category));
            return View(program);
        }

        // GET: StudyProgram/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var program = _context.StudyPrograms.Find(id);
            if (program == null) return NotFound();

            ViewBag.Categories = Enum.GetValues(typeof(Category));
            return View(program);
        }

        // POST: StudyProgram/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StudyProgram program)
        {
            if (id != program.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(program);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = Enum.GetValues(typeof(Category));
            return View(program);
        }

        // GET: StudyProgram/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var program = _context.StudyPrograms.Find(id);
            if (program == null) return NotFound();

            return View(program);
        }

        // POST: StudyProgram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var program = _context.StudyPrograms.Find(id);
            _context.StudyPrograms.Remove(program);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}