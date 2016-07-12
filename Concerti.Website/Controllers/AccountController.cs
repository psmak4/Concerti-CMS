using Concerti.Website.Core.User;
using Concerti.Website.Services.Interfaces;
using Concerti.Website.ViewModels.Account;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Concerti.Website.Controllers
{
	public class AccountController : BaseController
	{
		private IUserService userService;

		public AccountController(IUserService userService)
		{
			if (userService == null)
				throw new ArgumentNullException("userService");
			this.userService = userService;
		}

		[Route("login", Name = "Login")]
		public ActionResult Login(string returnUrl)
		{
			var model = new LoginViewModel();

			return View(model);
		}

		[Route("login")]
		[HttpPost()]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				try
				{
					AuthenticateUser(model.Username, model.Password);

					if (Url.IsLocalUrl(returnUrl))
						return Redirect(returnUrl);

					return RedirectToRoute("AdminDashboard");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}

			return View(model);
		}

		[Route("logout", Name = "Logout")]
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();

			return RedirectToRoute("SiteHome");
		}

		private void AuthenticateUser(string username, string password)
		{
			var user = userService.GetUser(username, password);
			if (user == null)
				throw new Exception("Invalid username/password given");

			var serializeModel = new CustomPrincipalSerializeModel()
			{
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserId = user.UserId,
				Username = user.Username
			};
			var serializer = new JavaScriptSerializer();
			var userData = serializer.Serialize(serializeModel);

			var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
			var encTicket = FormsAuthentication.Encrypt(authTicket);
			var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
			Response.Cookies.Add(faCookie);
		}
	}
}