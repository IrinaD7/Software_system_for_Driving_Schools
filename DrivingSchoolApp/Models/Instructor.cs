using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class Instructor : Employee
	{
		[Display(Name = "Категории вождения")]
		public List<Category> Categories { get; set; } = new List<Category>();

		[Display(Name = "Закреплённый автомобиль")]
		public int? AssignedVehicle { get; set; }
	}
}
