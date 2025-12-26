using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class PracticeExam : InternalExam
	{
		[Required]
		[Display(Name = "Экзаменатор")]
		public int InstructorId { get; set; }
		public Instructor Instructor{ get; set; }

		[Required]
		[Display(Name = "Транспортное средство")]
		public Vehicle Vehicle{ get; set; }

		[Required]
		[Display(Name = "Штрафные баллы")]
		public int PenaltyPoints { get; set; }

		[Required]
		[Display(Name = "Категория")]
		public Category Category{ get; set; }

	}
}
