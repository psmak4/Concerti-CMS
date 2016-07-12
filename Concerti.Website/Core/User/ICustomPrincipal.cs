using System.Security.Principal;

namespace Concerti.Website.Core.User
{
	public interface ICustomPrincipal : IPrincipal
	{
		string Email { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		int UserId { get; set; }
		string Username { get; set; }
	}
}