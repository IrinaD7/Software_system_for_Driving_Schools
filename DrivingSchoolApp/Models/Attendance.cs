using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class Attendance
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Студент")]
		public int StudentId { get; set; }

		public Student Student { get; set; }

		[Required]
		[Display(Name = "Занятие")]
		public int LessonId { get; set; }

		public  Lesson Lesson { get; set; }

		public bool IsPresent { get; set; }
	}
}
