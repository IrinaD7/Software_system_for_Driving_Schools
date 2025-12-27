using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class TheoryExam
	{
        public int Id { get; set; }

        [Required]
        [Display(Name = "Студент")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [Display(Name = "Экзаменатор")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        [Display(Name = "Дата экзамена")]
        public DateTime Date { get; set; }

        [Display(Name = "Результат")]
        public ExamResult Result { get; set; }

        [Required]
        [Display(Name = "Время прохождения")]
        public int Time { get; set; }

        [Required]
        [Display(Name = "Правильные ответы")]
        public int CorrectAnswers { get; set; }

        [Required]
        [Display(Name = "Неправильные ответы")]
        public int WrongAnswer { get; set; }

    }
}
