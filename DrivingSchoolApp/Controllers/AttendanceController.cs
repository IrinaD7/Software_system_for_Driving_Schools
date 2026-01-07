using DrivingSchoolApp.Data;
using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Teacher")]
public class AttendanceController : Controller
{
	private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public AttendanceController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
	{
		_context = context;
		_userManager = userManager;
	}

    public IActionResult Mark(int lessonId)
    {
        var lesson = _context.Lessons
            .Include(l => l.Group)
                .ThenInclude(g => g.Students)
            .FirstOrDefault(l => l.Id == lessonId);

        if (lesson == null)
            return NotFound();

        var existingAttendances = _context.Attendances
            .Where(a => a.LessonId == lessonId)
            .ToList();

        var model = new AttendanceViewModel
        {
            LessonId = lesson.Id,
            Students = lesson.Group.Students.Select(s =>
            {
                var attendance = existingAttendances
                    .FirstOrDefault(a => a.StudentId == s.Id);

                return new StudentAttendanceItem
                {
                    StudentId = s.Id,
                    FullName = $"{s.Surname} {s.Name}",
                    IsPresent = attendance?.IsPresent ?? true
                };
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Mark(AttendanceViewModel model)
	{
		foreach (var s in model.Students)
		{
			var attendance = _context.Attendances.FirstOrDefault(a =>
				a.StudentId == s.StudentId &&
				a.LessonId == model.LessonId);

			if (attendance == null)
			{
				_context.Attendances.Add(new Attendance
				{
					StudentId = s.StudentId,
					LessonId = model.LessonId,
					IsPresent = s.IsPresent
				});
			}
			else
			{
				attendance.IsPresent = s.IsPresent;
			}
		}

		_context.SaveChanges();
		return RedirectToAction("Index", "Lesson");
	}
}