using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class Application
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Статус")]
		public ApplicationStatus Status { get; set; }

		[Required]
		[Display(Name = "Студент")]
		public int StudentId { get; set; }

		public Student Student { get; set; }

		[Required]
		[Display(Name = "Дата")]
		public DateTime Date { get; set; }

	}
}
