using Concerti.Website.Models;
using Concerti.Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Concerti.Website.Services
{
	public class SettingService : ISettingService
	{
		private ConcertiEntities context;

		public SettingService(ConcertiEntities context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			this.context = context;
		}

		public IEnumerable<SettingOption> GetHomePageOptions()
		{
			var pages = context.Pages.Where(p => p.IsActive).AsEnumerable();
			List<SettingOption> options = new List<SettingOption>();
			foreach(var page in pages)
			{
				options.Add(new SettingOption()
				{
					Text = page.Title,
					Value = page.PageId.ToString()
				});
			}

			return options.AsEnumerable();
		}

		public string GetHomePageSettingTextValue(int pageId)
		{
			var page = context.Pages.FirstOrDefault(p => p.PageId == pageId);
			if (page == null)
				return string.Empty;

			return page.Title;
		}

		public Setting GetSetting(int settingId)
		{
			return context.Settings.FirstOrDefault(s => s.SettingId == settingId);
		}

		public IEnumerable<Setting> GetSettings()
		{
			return context.Settings.OrderBy(s => s.Name);
		}

		public Setting UpdateSetting(int settingId, string value)
		{
			var setting = GetSetting(settingId);
			if (setting == null)
				throw new Exception(SettingErrors.InvalidSettingId);

			setting.Value = value;

			context.SaveChanges();

			return setting;
		}
	}

	class SettingErrors
	{
		public const string InvalidSettingId = "Invalid setting id given";
	}
}