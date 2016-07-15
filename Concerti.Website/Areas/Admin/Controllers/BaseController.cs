using Concerti.Website.Areas.Admin.Models;
using Concerti.Website.Areas.Admin.ViewModels.Base;
using Concerti.Website.Core.User;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Concerti.Website.Areas.Admin.Controllers
{
	[Authorize()]
	public class BaseController : Controller
	{
		protected virtual new CustomPrincipal User
		{
			get { return HttpContext.User as CustomPrincipal; }
		}

		public BaseController()
		{
		}

		[ChildActionOnly()]
		public ActionResult Navigation()
		{
			var model = GetNavigationItems();

			return PartialView(model);
		}

		[ChildActionOnly()]
		public ActionResult Alerts()
		{
			if (!TempData.ContainsKey(Alert.TempDataKey))
				return new EmptyResult();

			var model = (IEnumerable<Alert>)TempData[Alert.TempDataKey];

			return PartialView(model);
		}

		protected void AddErrorAlert(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
				return;

			AddAlert(message, AlertTypes.Error);
		}

		protected void AddInfoAlert(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
				return;

			AddAlert(message, AlertTypes.Information);
		}

		protected void AddSuccessAlert(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
				return;

			AddAlert(message, AlertTypes.Success);
		}

		private void AddAlert(string message, string type)
		{
			var alerts = TempData.ContainsKey(Alert.TempDataKey) ? (List<Alert>)TempData[Alert.TempDataKey] : new List<Alert>();
			alerts.Add(new Alert()
			{
				Message = message,
				AlertType = type,
				Dismissable = true
			});

			TempData[Alert.TempDataKey] = alerts;
		}

		private IEnumerable<NavigationViewModel> GetNavigationItems()
		{
			var navigation = new List<NavigationViewModel>();
			var currentUrl = string.Format("{0}{1}{2}", Request.Url.Segments[0], Request.Url.Segments[1], Request.Url.Segments[2]);
			if (currentUrl.EndsWith("/"))
				currentUrl = currentUrl.Substring(0, currentUrl.Length - 1);

			navigation.Add(new NavigationViewModel(Url.RouteUrl("AdminDashboard"), "dashboard", "Dashboard", currentUrl));
			navigation.Add(new NavigationViewModel(Url.RouteUrl("AdminPagesList"), "file", "Pages", currentUrl));
			navigation.Add(new NavigationViewModel(Url.RouteUrl("AdminUsersList"), "users", "Users", currentUrl));
			navigation.Add(new NavigationViewModel(Url.RouteUrl("AdminSettingsList"), "cogs", "Settings", currentUrl));
			navigation.Add(new NavigationViewModel(Url.RouteUrl("Logout"), "sign-out", "Logout", currentUrl));

			return navigation.AsEnumerable();
		}
	}
}