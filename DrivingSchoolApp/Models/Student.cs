using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
    public class Student : Person
    {
		[Display(Name = "Учебная группа")]
        public int? GroupId {  get; set; }
		public StudyGroup? Group { get; set; }  

        public Student()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Patronymic = string.Empty;
            Phone = string.Empty;
            Passport = string.Empty;
        }

    }
}
