using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
    public class Person
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Введите фамилию")]
        [Display(Name ="Фамилия")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string name { get; set; }

        [Display(Name = "Отчество")]
        public string patronymic { get; set; }

        [Phone(ErrorMessage ="Введите номер корректно")]
        [Display(Name = "Телефон")]
        public string phone { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime birthDate { get; set; }

        [Required(ErrorMessage = "Введите паспортные данные")]
        [Display(Name = "Пасспортные данные")]
        public string passport { get; set; }

    }
}
