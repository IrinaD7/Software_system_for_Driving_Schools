using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DrivingSchoolApp.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Введите фамилию")]
        [Display(Name ="Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Phone(ErrorMessage ="Введите номер корректно")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Введите паспортные данные")]
        [Display(Name = "Пасспортные данные")]
        public string Passport { get; set; }

    }
}
