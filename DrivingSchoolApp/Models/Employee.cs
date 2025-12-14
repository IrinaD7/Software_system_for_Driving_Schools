using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
    public class Employee : Person
    {
        [Display(Name = "Водительское удостоверение")]
        public string DriverLicense {  get; set; }

        [Range(0, 60, ErrorMessage ="Опыт работы должен быть от 0 до 60 лет")]
        [Display(Name = "Опыт работы (лет)")]
        public int Experience { get; set; }

        [Display(Name = "Квалификация")]
        public string Qualification {  get; set; }
    }
}
