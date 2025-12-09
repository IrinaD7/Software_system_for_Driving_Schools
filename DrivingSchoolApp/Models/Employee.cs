using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
    public class Employee : Person
    {
        [Display(Name = "Водительское удостоверение")]
        public string driverLicense {  get; set; }

        [Range(0, 60, ErrorMessage ="Опыт работы должен быть от 0 до 60 лет")]
        [Display(Name = "Опыт работы (лет)")]
        public int experience { get; set; }

        [Display(Name = "Квалификация")]
        public string qualification {  get; set; }
    }
}
