using Concerti.Website.Areas.Admin.ViewModels.Pages;
using Concerti.Website.Services.Interfaces;
using System;
using System.Web.Mvc;

namespace Concerti.Website.Areas.Admin.Controllers
{
	[RouteArea("Admin")]
	public class PagesController : BaseController
	{
		private IPageService pageService;

		public PagesController(IPageService pageService)
		{
			if (pageService == null)
				throw new ArgumentNullException("pageService");
			this.pageService = pageService;
		}

		[Route("", Name = "AdminIndex")]
		[Route("dashboard", Name = "AdminDashboard")]
		public ActionResult Dashboard()
		{
			return View();
		}

		[Route("pages", Name = "AdminPagesList")]
		public ActionResult Index()
		{
			var pages = pageService.GetPages();

			return View(pages);
		}

		[Route("pages/new", Name = "AdminPageNew")]
		public ActionResult Create()
		{
			var model = new CreateViewModel();

			return View(model);
		}

		[Route("pages/new")]
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var page = pageService.CreatePage(model.Title, model.Slug, model.Content, model.IsActive, model.DisplayTitle, User.UserId);
					AddSuccessAlert("New page created: " + page.Title);

					return RedirectToRoute("AdminPagesList");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}

			return View(model);
		}

		[Route("pages/{pageId:int}/edit", Name = "AdminPageEdit")]
		public ActionResult Edit(int pageId)
		{
			var page = pageService.GetPage(pageId);
			if (page == null)
				return RedirectToRoute("AdminPagesList");

			var model = new EditViewModel()
			{
				PageId = page.PageId,
				Title = page.Title,
				Slug = page.Slug,
				Content = page.Content,
				IsActive = page.IsActive,
				DisplayTitle = page.DisplayTitle
			};

			return View(model);
		}

		[Route("pages/{pageId:int}/edit")]
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(EditViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var page = pageService.UpdatePage(model.PageId, model.Title, model.Slug, model.Content, model.IsActive, model.DisplayTitle, User.UserId);
					AddSuccessAlert("Page updated: " + page.Title);

					return RedirectToRoute("AdminPagesList");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}

			return View(model);
		}

		[Route("pages/{pageId:int}/delete", Name = "AdminPageDelete")]
		public ActionResult Delete(int pageId)
		{
			try
			{
				var page = pageService.DeletePage(pageId);
				AddSuccessAlert("Page deleted: " + page.Title);
			}
			catch (Exception ex)
			{
				AddErrorAlert(ex.Message);
			}

			return RedirectToRoute("AdminPagesList");
		}
	}
}