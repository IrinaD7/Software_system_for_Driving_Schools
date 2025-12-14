using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
    public class Student : Person
    {
        [Display(Name = "Статус обучения")]
        public StudentStatus Status { get; set; } = StudentStatus.Pending;

		[Display(Name = "Учебная группа")]
		public StudyGroup Group { get; set; }
    }

    public enum StudentStatus
    {
        [Display(Name = "Ожидание начала занятий")]
        Pending,

        [Display(Name = "Прохождение теории")]
        TheoryInProgress,

        [Display(Name = "Прохождение практики")]
        PracticInProgress,

        [Display(Name = "Внутренние экзамены")]
        InternalExams,

        [Display(Name = "Государственные экзамены")]
        StateExams,

        [Display(Name = "Окончил обучение")]
        Graduated,

        [Display(Name = "Отчислен")]
        Expelled
    }
}
