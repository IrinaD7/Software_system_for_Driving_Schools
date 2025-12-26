using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolApp.Models
{
	public class UserProfile
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string IdentityUserId { get; set; }

		public IdentityUser IdentityUser { get; set; }

		public int PersonId {  get; set; }
		public Person Person {  get; set; }
	}
}
