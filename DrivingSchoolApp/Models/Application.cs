using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class Application
	{
		[Required]
		[Display(Name = "Статус")]
		public Application Status { get; set; }

		[Required]
		[Display(Name = "Студент")]
		public int StudentId { get; set; }

		public Student Student { get; set; }

		[Required]
		[Display(Name = "Дата")]
		public DateTime Date { get; set; }

	}
}
