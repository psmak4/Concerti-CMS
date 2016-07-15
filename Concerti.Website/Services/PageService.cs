using Concerti.Website.Models;
using Concerti.Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Concerti.Website.Services
{
	public class PageService : IPageService
	{
		private ConcertiEntities context;

		public PageService(ConcertiEntities context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			this.context = context;
		}

		public Page CreatePage(string title, string slug, string content, bool isActive, bool displayTitle, int createdBy)
		{
			var page = GetPage(slug);
			if (page != null)
				throw new Exception("Slug", new Exception(PageErrors.SlugExists));

			page = new Page()
			{
				Title = title,
				Slug = slug,
				Content = content,
				IsActive = isActive,
				DisplayTitle = displayTitle,
				CreatedBy = createdBy,
				DateCreated = DateTime.Now
			};
			context.Pages.Add(page);

			context.SaveChanges();

			return page;
		}

		public Page DeletePage(int pageId)
		{
			var page = GetPage(pageId);
			if (page == null)
				throw new Exception(PageErrors.InvalidPageId);

			context.Pages.Remove(page);

			context.SaveChanges();

			return page;
		}

		public Page GetHomePage()
		{
			var setting = context.Settings.FirstOrDefault(s => s.Name.Equals("Home Page", StringComparison.OrdinalIgnoreCase));
			if (setting == null)
				return null;

			var pageId = int.Parse(setting.Value);

			return context.Pages.FirstOrDefault(p => p.PageId == pageId);
		}

		public Page GetPage(string slug)
        {
            return context.Pages.FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase) && p.IsActive);
        }

        public Page GetPage(int pageId)
		{
			return context.Pages.FirstOrDefault(p => p.PageId == pageId);
		}

		public IEnumerable<Page> GetActivePages()
		{
			return context.Pages.Where(p => p.IsActive).AsEnumerable();
		}

		public IEnumerable<Page> GetPages()
		{
			return context.Pages.AsEnumerable();
		}

		public Page UpdatePage(int pageId, string title, string slug, string content, bool isActive, bool displayTitle, int updatedBy)
		{
			var page = GetPage(pageId);
			if (page == null)
				throw new Exception(PageErrors.InvalidPageId);

			if (!page.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase))
			{
				var slugPage = GetPage(slug);
				if (slugPage == null)
					throw new Exception("Slug", new Exception(PageErrors.SlugExists));
			}

			page.Title = title;
			page.Slug = slug;
			page.Content = content;
			page.IsActive = isActive;
			page.DisplayTitle = displayTitle;
			page.LastUpdatedBy = updatedBy;
			page.DateLastUpdated = DateTime.Now;

			context.SaveChanges();

			return page;
		}
	}

	class PageErrors
	{
		public const string InvalidPageId = "Invalid page id given";
		public const string SlugExists = "A page already exists with that slug";
	}
}