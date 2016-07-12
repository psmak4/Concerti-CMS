using Concerti.Website.Models;
using System.Collections.Generic;

namespace Concerti.Website.Services.Interfaces
{
	public interface IUserService
	{
		User CreateUser(string username, string password, string email, string firstName, string lastName);

		User DeleteUser(int userId);

		IEnumerable<User> GetActiveUsers();

		User GetUser(string username);

		User GetUser(int userId);

		User GetUser(string username, string password);

		IEnumerable<User> GetUsers();

		User ResetPassword(int userId, string password);

		User UpdateUser(int userId, string email, string firstName, string lastName);
	}
}