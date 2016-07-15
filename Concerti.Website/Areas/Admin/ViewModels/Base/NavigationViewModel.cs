using System;

namespace Concerti.Website.Areas.Admin.ViewModels.Base
{
	public class NavigationViewModel
	{
		public string LinkUrl { get; set; }

		public string LinkCssClass { get; set; }

		public string IconCssClass { get; set; }

		public string Text { get; set; }

		public NavigationViewModel()
		{
		}

		public NavigationViewModel(string linkUrl, string iconCssClass, string text, string currentUrl)
		{
			LinkUrl = linkUrl;
			Text = text;
			IconCssClass = iconCssClass;
			LinkCssClass = linkUrl.StartsWith(currentUrl, StringComparison.OrdinalIgnoreCase) ? "nav__link--active" : string.Empty;
		}
	}
}