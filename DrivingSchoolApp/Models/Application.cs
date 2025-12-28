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
		[Display(Name = "Дата")]
		public DateTime Date { get; set; }

		[Display(Name = "Срок оплаты")]
		public DateTime? PaymentDeadline { get; set; }

		public int StudyProgramId { get; set; }
		public StudyProgram? StudyProgram { get; set; }

        [Display(Name = "Студент")]
        public int? StudentId { get; set; }

        public Student? Student { get; set; }

		[Required]
		public string Surname { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Patronymic { get; set;} = string.Empty;

        [Required]
		public DateTime BirthDate { get; set; }

		[Required]
		public string Passport {  get; set; } = string.Empty;
    }
}
