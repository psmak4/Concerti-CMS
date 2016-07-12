using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Concerti.Website.Areas.Admin.ViewModels.Pages
{
	public class EditViewModel
	{
		[Required()]
		public int PageId { get; set; }

		[Required()]
		[DisplayName("Title")]
		[DataType(DataType.Text)]
		public string Title { get; set; }

		[Required()]
		[DisplayName("Slug")]
		[DataType(DataType.Text)]
		public string Slug { get; set; }

		[Required()]
		[DataType(DataType.MultilineText)]
		[AllowHtml()]
		public string Content { get; set; }

		[Required()]
		[DisplayName("Active")]
		public bool IsActive { get; set; }

		[Required()]
		[DisplayName("Display Title")]
		public bool DisplayTitle { get; set; }
	}
}