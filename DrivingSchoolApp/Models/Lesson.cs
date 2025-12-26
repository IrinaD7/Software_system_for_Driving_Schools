using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class Lesson
	{
		public int Id { get; set; }

		[Display(Name = "Преподаватель")]
		public int TeacherId { get; set; }

		public Teacher Teacher{ get; set; }


		[Display(Name = "Аудитория")]
		public string Classroom{ get; set; }

		[Display(Name = "Дата и время")]
		public DateTime Date { get; set; }

		[Display(Name = "Учебная группа")]
		public StudyGroup Group { get; set; }
	}
}
