using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models.Admin
{
	public class CreateUserViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Role { get; set; }

		[Required]
		public int PersonId {  get; set; }
	}
}
