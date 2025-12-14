using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class StudyProgram
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Введите категорию")]
		[Display(Name = "Категория обучения")]
		public Category Category { get; set; }

		[Required(ErrorMessage = "Введите количество часов")]
		[Display(Name = "Количество теоретических часов")]
		public int TheoryHours{ get; set; }

		[Required(ErrorMessage = "Введите количество часов")]
		[Display(Name = "Количество практических часов")]
		public int PracticeHours { get; set; }

		[Required(ErrorMessage = "Введите стоимость обучения")]
		[Display(Name = "Стоимость обучения")]
		public decimal Cost { get; set; }
	}
}
