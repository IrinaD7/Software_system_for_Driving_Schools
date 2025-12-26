using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public abstract class InternalExam
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Дата экзамена")]
		public DateTime Date { get; set; }

		[Required]
		[Display(Name = "Студент")]
		public int StudentId {  get; set; }

		public Student Student { get; set; }

		[Display(Name = "Результат")]
		public ExamResult Result {  get; set; }		
	}
}
