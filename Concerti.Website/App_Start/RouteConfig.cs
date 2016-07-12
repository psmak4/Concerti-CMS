using System.Web.Mvc;
using System.Web.Routing;

namespace Concerti.Website
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.LowercaseUrls = true;

			routes.MapMvcAttributeRoutes();

			routes.MapRoute(
				name: "CatchAll",
				url: "{slug}",
				defaults: new { controller = "Pages", action = "Page", slug = UrlParameter.Optional },
				namespaces: new[] { "Concerti.Website.Controllers" }
			);
		}
	}
}