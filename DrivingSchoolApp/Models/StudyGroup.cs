using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class StudyGroup
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Введите название группы")]
		[Display(Name = "Название группы")]
		public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите учебную программу")]
		[Display(Name = "Учебная программа")]
        public int StudyProgramId { get; set; }
        public StudyProgram? StudyProgram { get; set; }

		[Display(Name = "Дата начала обучения")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Дата окончания обучения")]
		public DateTime EndDate { get; set; }

		public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
