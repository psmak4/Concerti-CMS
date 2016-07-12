using Concerti.Website.Areas.Admin.Models;
using Concerti.Website.Core.User;
using System.Collections.Generic;
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
	}
}