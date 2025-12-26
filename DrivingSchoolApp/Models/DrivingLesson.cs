using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class DrivingLesson
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите ученика")]
		[Display(Name = "Ученик")]
		public int StudentId { get; set; }	

		public Student Student { get; set; }


		[Required(ErrorMessage = "Укажите инструктора")]
		[Display(Name = "Инструктор")]
		public int InstructorId { get; set; }

		public Instructor Instructor { get; set; }


		[Required(ErrorMessage = "Укажите транспортное средство")]
		[Display(Name = "Транспортное средство")]
		public Vehicle Vehicle { get; set; }
		public int VehicleId { get; set; }

		[Required(ErrorMessage = "Укажите дату и время")]
		[Display(Name = "Дата и время")]
		public DateTime Date { get; set; }

		[Range(1,5,ErrorMessage="Оценка должна быть от 1 до 5")]
		[Display(Name = "Оценка")]
		public int? Grade { get; set; }

		[Display(Name = "Комментарий")]
		public string Comment { get; set; }


	}
}
