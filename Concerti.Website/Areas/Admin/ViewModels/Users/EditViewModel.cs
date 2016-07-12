using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concerti.Website.Areas.Admin.ViewModels.Users
{
	public class EditViewModel
	{
		[Required()]
		public int UserId { get; set; }

		public string Username { get; set; }

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