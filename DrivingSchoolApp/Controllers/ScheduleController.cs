using DrivingSchoolApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolApp.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lessons = _context.Lessons
                .Include(l => l.Group)
                .Include(l => l.Teacher)
                .OrderBy(l => l.Date)
                .ToList();

            return View(lessons);
        }
    }
}