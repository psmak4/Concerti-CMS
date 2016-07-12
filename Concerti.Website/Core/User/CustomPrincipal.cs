using System.Security.Principal;

namespace Concerti.Website.Core.User
{
	public class CustomPrincipal : ICustomPrincipal
	{
		public string Email { get; set; }

		public string FirstName { get; set; }

		public IIdentity Identity { get; private set; }

		public string LastName { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public CustomPrincipal(string username)
		{
			Identity = new GenericIdentity(username);
		}

		public bool IsInRole(string role)
		{
			return false;
		}
	}
}