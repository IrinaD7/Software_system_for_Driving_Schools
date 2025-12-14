using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class StudyProgram
	{
		public int Id { get; set; }

		[Display(Name = "Категория обучения")]
		public Category Category { get; set; }

		[Display(Name = "Количество теоретических часов")]
		public int TheoryHours{ get; set; }

		[Display(Name = "Количество практических часов")]
		public int PracticeHours { get; set; }

		[Display(Name = "Стоимость обучения")]
		public decimal Cost { get; set; }
	}
}
