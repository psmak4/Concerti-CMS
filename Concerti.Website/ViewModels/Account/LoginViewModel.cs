using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concerti.Website.ViewModels.Account
{
	public class LoginViewModel
	{
		[Required()]
		[DataType(DataType.Text)]
		[DisplayName("Username")]
		public string Username { get; set; }

		[Required()]
		[DataType(DataType.Password)]
		[DisplayName("Password")]
		public string Password { get; set; }
	}
}