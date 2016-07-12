using Concerti.Website.Areas.Admin.ViewModels.Users;
using Concerti.Website.Services.Interfaces;
using System;
using System.Web.Mvc;

namespace Concerti.Website.Areas.Admin.Controllers
{
	[RouteArea("Admin")]
	public class UsersController : BaseController
	{
		private IUserService userService;

		public UsersController(IUserService userService)
		{
			if (userService == null)
				throw new ArgumentNullException("userService");
			this.userService = userService;
		}

		[Route("users", Name = "AdminUsersList")]
		public ActionResult Index()
		{
			var users = userService.GetActiveUsers();

			return View(users);
		}

		[Route("users/new", Name = "AdminUserNew")]
		public ActionResult Create()
		{
			var model = new CreateViewModel();

			return View(model);
		}

		[Route("users/new")]
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = userService.CreateUser(model.Username, model.Password, model.Email, model.FirstName, model.LastName);
					AddSuccessAlert("New user created: " + user.Username);

					return RedirectToRoute("AdminUsersList");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}

			return View(model);
		}

		[Route("users/{userId:int}/edit", Name = "AdminUserEdit")]
		public ActionResult Edit(int userId)
		{
			var user = userService.GetUser(userId);
			if (user == null)
				return RedirectToRoute("AdminUsersList");

			var model = new EditViewModel()
			{
				UserId = user.UserId,
				Email = user.Email,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName
			};

			return View(model);
		}

		[Route("users/{userId:int}/edit")]
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(EditViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = userService.UpdateUser(model.UserId, model.Email, model.FirstName, model.LastName);
					AddSuccessAlert("User updated: " + user.Username);

					return RedirectToRoute("AdminUsersList");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}

			var editUser = userService.GetUser(model.UserId);
			if (editUser == null)
				return RedirectToRoute("AdminUsersList");

			model.Username = editUser.Username;

			return View(model);
		}

		[Route("users/{userId:int}", Name = "AdminUserDetails")]
		public ActionResult Details(int userId)
		{
			var user = userService.GetUser(userId);
			if (user == null)
				return RedirectToRoute("AdminUsersList");

			return View(user);
		}

		[Route("users/{userId:int}/resetpassword", Name = "AdminUserResetPassword")]
		public ActionResult ResetPassword(int userId)
		{
			var user = userService.GetUser(userId);
			if (user == null)
				return RedirectToRoute("AdminUsersList");

			var model = new ResetPasswordViewModel()
			{
				UserId = user.UserId,
				Username = user.Username
			};

			return View(model);
		}

		[Route("users/{userId:int}/resetpassword")]
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = userService.ResetPassword(model.UserId, model.Password);
					AddSuccessAlert("User password reset: " + user.Username);

					return RedirectToRoute("AdminUsersList");
				}
				catch(Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}

			var resetUser = userService.GetUser(model.UserId);
			if (resetUser == null)
				return RedirectToRoute("AdminUsersList");

			model.Username = resetUser.Username;

			return View(model);
		}

		[Route("users/{userId:int}/delete", Name = "AdminUserDelete")]
		public ActionResult Delete(int userId)
		{
			try
			{
				var user = userService.DeleteUser(userId);
				AddSuccessAlert("User deleted: " + user.Username);
			}
			catch (Exception ex)
			{
				AddErrorAlert(ex.Message);
			}

			return RedirectToRoute("AdminUsersList");
		}
	}
}