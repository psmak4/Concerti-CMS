using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concerti.Website.Areas.Admin.ViewModels.Users
{
	public class CreateViewModel
	{
		[Required()]
		[DisplayName("Username")]
		[DataType(DataType.Text)]
		public string Username { get; set; }

		[Required()]
		[DisplayName("Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required()]
		[DisplayName("Confirm Password")]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }

		[Required()]
		[DisplayName("Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DisplayName("First Name")]
		[DataType(DataType.Text)]
		[MaxLength(100)]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		[DataType(DataType.Text)]
		[MaxLength(100)]
		public string LastName { get; set; }
	}
}