using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Concerti.Website.Areas.Admin.ViewModels.Settings
{
	public class EditViewModel
	{
		[Required()]
		public int SettingId { get; set; }

		public string Name { get; set; }

		[Required()]
		[DisplayName("Value")]
		[DataType(DataType.Text)]
		public string Value { get; set; }

		public IEnumerable<SelectListItem> Options { get; set; }
	}
}