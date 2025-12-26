using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class TheoryExam : InternalExam
	{
		[Required]
		[Display(Name = "Экзаменатор")]
		public int TeacherId { get; set; }
		public Teacher Teacher { get; set; }

		[Required]
		[Display(Name = "Время прохождения")]
		public int Time {  get; set; }

		[Required]
		[Display(Name = "Правильные ответы")]
		public int CorrectAnswers {  get; set; }

		[Required]
		[Display(Name = "Неправлильные ответы")]
		public int WrongAnswer { get; set; }

	}
}
