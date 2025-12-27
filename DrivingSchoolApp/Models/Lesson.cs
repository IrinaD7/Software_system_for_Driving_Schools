using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class Lesson
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "Выберите преподавателя")]
        [Display(Name = "Преподаватель")]
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        [Required(ErrorMessage = "Введите аудиторию")]
        [StringLength(50, ErrorMessage = "Название аудитории не должно превышать 50 символов")]
        [Display(Name = "Аудитория")]
        public string Classroom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите дату и время")]
        [Display(Name = "Дата и время")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Выберите учебную группу")]
        [Display(Name = "Учебная группа")]
        public int GroupId { get; set; }

        public StudyGroup? Group { get; set; }
    }
}
