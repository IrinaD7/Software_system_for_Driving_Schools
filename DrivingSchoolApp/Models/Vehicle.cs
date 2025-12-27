using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class Vehicle
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Введите модель")]
		[Display(Name = "Модель")]
		public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите VIN")]
		[Display(Name = "VIN")]
		public string VIN { get; set; } = string.Empty;

        [Display(Name = "Цвет")]
		public string Color { get; set; } = string.Empty;

        [Display(Name = "Трансмиссия")]
		public Transmission Transmission { get; set; }

		[Display(Name = "Тип привода")]
		public DriveType DriveType { get; set; }

		[Display(Name = "Категория")]
		public Category Category { get; set; }

		[Display(Name = "Год выпуска")]
		public int ManufactureYear { get; set; }

		[Display(Name = "Техническое состояние")]
		public TechnicalCondition TechnicalCondition { get; set; }

		public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
