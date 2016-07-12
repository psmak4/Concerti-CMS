using Concerti.Website.Core.User;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Concerti.Website
{
	public class Global : HttpApplication
	{
		private void Application_Start(object sender, EventArgs e)
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			AreaRegistration.RegisterAllAreas();
		}

		protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
		{
			var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			if (authCookie != null)
			{
				var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
				var serializer = new JavaScriptSerializer();
				var serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);
				var user = new CustomPrincipal(authTicket.Name)
				{
					Email = serializeModel.Email,
					FirstName = serializeModel.FirstName,
					LastName = serializeModel.LastName,
					UserId = serializeModel.UserId,
					Username = serializeModel.Username
				};
				Context.User = user;
			}
			else
			{
				Context.User = new CustomPrincipal(string.Empty);
			}
		}
	}
}