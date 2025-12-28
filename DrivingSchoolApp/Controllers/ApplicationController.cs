using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class ApplicationController : Controller
{
    private readonly ApplicationDbContext _context;

    public ApplicationController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var applications = _context.Applications
            .Include(a => a.StudyProgram)
            .ToList();

        return View(applications);
    }

    public IActionResult Create()
    {
        ViewBag.Programs = _context.StudyPrograms.ToList();
        return View();
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public IActionResult Create(Application application)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        ViewBag.Programs = _context.StudyPrograms.ToList();
    //        return View(application);
    //    }

    //    application.Date = DateTime.Now;

    //    bool exists = _context.Students.Any(s =>
    //        s.Passport == application.Passport &&
    //        s.BirthDate == application.BirthDate);

    //    application.Status = exists
    //        ? ApplicationStatus.Rejected
    //        : ApplicationStatus.WaitingPayment;

    //    _context.Applications.Add(application);
    //    _context.SaveChanges();

    //    return RedirectToAction(nameof(Index));
    //}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Application application)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Programs = _context.StudyPrograms.ToList();
            return View(application);
        }

        application.Date = DateTime.Now;

        bool studentExists = _context.Students.Any(s =>
            s.Passport == application.Passport &&
            s.BirthDate.Date == application.BirthDate.Date); 

     
        if (studentExists)
        {
            application.Status = ApplicationStatus.Rejected;
            TempData["Message"] = "Студент с такими паспортными данными уже существует. Заявка отклонена.";
        }
        else
        {
            application.Status = ApplicationStatus.WaitingPayment;
        }

        _context.Applications.Add(application);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Approve(int id)
    {
        var application = _context.Applications.Find(id);
        if (application == null) return NotFound();

        application.Status = ApplicationStatus.Approved;

        var student = new Student
        {
            Surname = application.Surname,
            Name = application.Name,
            Patronymic = application.Patronymic,
            BirthDate = application.BirthDate,
            Passport = application.Passport
        };

        _context.Students.Add(student);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Reject(int id)
    {
        var application = _context.Applications.Find(id);
        if (application == null) return NotFound();

        application.Status = ApplicationStatus.Rejected;
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var application = _context.Applications.Find(id);
        if (application == null) return NotFound();

        _context.Applications.Remove(application);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}