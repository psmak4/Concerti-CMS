using Concerti.Website.Services.Interfaces;
using Concerti.Website.ViewModels.Pages;
using System;
using System.Web.Mvc;

namespace Concerti.Website.Controllers
{
	public class PagesController : BaseController
	{
		private IPageService pageService;

		public PagesController(IPageService pageService)
		{
			if (pageService == null)
				throw new ArgumentNullException("pageService");
			this.pageService = pageService;
		}

		[Route("~/", Name = "SiteHome")]
		public ActionResult Index()
		{
			var page = pageService.GetHomePage();
			if (page == null)
				return NotFound();

			var model = new PageViewModel()
			{
				Content = page.Content,
				PageId = page.PageId,
				Title = page.Title,
				DisplayTitle = page.DisplayTitle
			};

			return View("Page", model);
		}

		public ActionResult Page(string slug)
		{
			var page = pageService.GetPage(slug);
			if (page == null)
				return NotFound();

			var model = new PageViewModel()
			{
				Content = page.Content,
				PageId = page.PageId,
				Title = page.Title,
				DisplayTitle = page.DisplayTitle
			};

			return View(model);
		}

		[Route("SiteNavigation", Name = "SiteNavigation")]
		[ChildActionOnly()]
		public ActionResult SiteNavigation()
		{
			return PartialView();
		}

		[Route("NotFound", Name = "NotFound")]
		public ActionResult NotFound()
		{
			Response.StatusCode = 404;

			return View("NotFound");
		}

		[Route("ServerError", Name = "ServerError")]
		public ActionResult ServerError()
		{
			Response.StatusCode = 500;

			return View("ServerError");
		}
	}
}