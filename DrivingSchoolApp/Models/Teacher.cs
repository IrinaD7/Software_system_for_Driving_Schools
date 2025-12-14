using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
    public class Teacher : Employee
    {
        [Display(Name ="Специализация")]
        public string Specialization {  get; set; }
    }
}
