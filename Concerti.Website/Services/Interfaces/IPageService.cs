using Concerti.Website.Models;
using System.Collections.Generic;

namespace Concerti.Website.Services.Interfaces
{
	public interface IPageService
	{
		Page CreatePage(string title, string slug, string content, bool isActive, bool displayTitle, int createdBy);

		Page DeletePage(int pageId);

		Page GetHomePage();

        Page GetPage(string slug);

        Page GetPage(int pageId);

		IEnumerable<Page> GetActivePages();

        IEnumerable<Page> GetPages();

		Page UpdatePage(int pageId, string title, string slug, string content, bool isActive, bool displayTitle, int updatedBy);
	}
}