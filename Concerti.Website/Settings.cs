using Concerti.Website.Models;
using System.Collections.Generic;
using System.Linq;

namespace Concerti.Website
{
	public class Settings
	{
		private static bool isInitialized = false;
		private static IList<Setting> settings;

		public static void GetSettings()
		{
			using (var context = new ConcertiEntities())
			{
				settings = context.Settings.ToList();
				isInitialized = true;
			}
		}

		private static string GetSetting(string name)
		{
			if (!isInitialized)
				GetSettings();

			var setting = settings.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
			if (setting == null)
				return string.Empty;

			return setting.Value;
		}

		public static bool IsSiteLive
		{
			get
			{
				var setting = GetSetting("Is Site Live");
				if (string.IsNullOrWhiteSpace(setting))
					return false;

				if (setting.ToLower() == "yes")
					return true;

				return false;
			}
		}

		public static string SiteName
		{
			get
			{
				return GetSetting("Site Name");
			}
		}
	}
}