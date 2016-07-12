using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concerti.Website.Areas.Admin.ViewModels.Users
{
	public class ResetPasswordViewModel
	{
		[Required()]
		public int UserId { get; set; }

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
	}
}