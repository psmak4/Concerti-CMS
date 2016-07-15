using Concerti.Website.Models;
using Concerti.Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Concerti.Website.Services
{
	public class UserService : IUserService
	{
		private ConcertiEntities context;

		public UserService(ConcertiEntities context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			this.context = context;
		}

		public User CreateUser(string username, string password, string email, string firstName, string lastName)
		{
			var user = GetUser(username);
			if (user != null)
				throw new Exception("Username", new Exception(UserErrors.UsernameTaken));

			var workFactor = ConfigurationManager.AppSettings["BCryptWorkFactor"];
			user = new User()
			{
				Username = username,
				Password = BCrypt.Net.BCrypt.HashPassword(password, int.Parse(workFactor)),
				Email = email,
				EmailConfirmed = false,
				FirstName = firstName,
				LastName = lastName,
				DateCreated = DateTime.Now
			};
			context.Users.Add(user);

			context.SaveChanges();

			return user;
		}

		public User DeleteUser(int userId)
		{
			var user = GetUser(userId);
			if (user == null)
				throw new Exception(UserErrors.InvalidUserId);

			user.IsActive = false;

			context.SaveChanges();

			return user;
		}

		public IEnumerable<User> GetActiveUsers()
		{
			return context.Users.Where(u => u.IsActive == true).AsEnumerable();
		}

		public User GetUser(string username)
		{
			return context.Users.FirstOrDefault(u => u.Username == username);
		}

		public User GetUser(int userId)
		{
			return context.Users.FirstOrDefault(u => u.UserId == userId);
		}

		public User GetUser(string username, string password)
		{
			var user = context.Users.FirstOrDefault(u => u.Username == username);
			if (user == null)
				return null;

			if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
				return null;

			return user;
		}

		public IEnumerable<User> GetUsers()
		{
			return context.Users.AsEnumerable();
		}

		public User ResetPassword(int userId, string password)
		{
			var user = GetUser(userId);
			if (user == null)
				throw new Exception(UserErrors.InvalidUserId);

			var workFactor = ConfigurationManager.AppSettings["BCryptWorkFactor"];
			user.Password = BCrypt.Net.BCrypt.HashPassword(password, int.Parse(workFactor));

			context.SaveChanges();

			return user;
		}

		public User UpdateUser(int userId, string email, string firstName, string lastName)
		{
			var user = GetUser(userId);
			if (user == null)
				throw new Exception(UserErrors.InvalidUserId);

			user.Email = email;
			user.FirstName = firstName;
			user.LastName = lastName;

			context.SaveChanges();

			return user;
		}
	}

	class UserErrors
	{
		public const string InvalidUserId = "Invalid user id given";
		public const string UsernameTaken = "Username already taken";
	}
}