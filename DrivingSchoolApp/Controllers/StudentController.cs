using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolApp.Controllers
{
	public class StudentController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StudentController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Student
		public IActionResult Index()
		{
			var students = _context.Students.Include(s => s.Group).ToList();
			return View(students);
		}

		// GET: Student/Create
		public IActionResult Create()
		{
			ViewBag.Groups = _context.StudyGroups.ToList();
			return View();
		}

		// POST: Student/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Student student)
		{
			if (ModelState.IsValid)
			{
				_context.Add(student);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.Groups = _context.StudyGroups.ToList();
			return View(student);
		}

		// GET: Student/Edit/5
		public IActionResult Edit(int id)
		{
			var student = _context.Students.Find(id);
			if (student == null) return NotFound();
			ViewBag.Groups = _context.StudyGroups.ToList();
			return View(student);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Student student)
		{
			if (ModelState.IsValid)
			{
				_context.Update(student);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.Groups = _context.StudyGroups.ToList();
			return View(student);
		}

		// GET: Student/Delete/5
		public IActionResult Delete(int id)
		{
			var student = _context.Students.Find(id);
			if (student == null) return NotFound();
			return View(student);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var student = _context.Students.Find(id);
			_context.Students.Remove(student);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
