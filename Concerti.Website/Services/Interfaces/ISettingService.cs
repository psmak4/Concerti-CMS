using Concerti.Website.Models;
using System.Collections.Generic;

namespace Concerti.Website.Services.Interfaces
{
	public interface ISettingService
	{
		Setting GetSetting(int settingId);

		IEnumerable<SettingOption> GetHomePageOptions();

		string GetHomePageSettingTextValue(int pageId);

		IEnumerable<Setting> GetSettings();

		Setting UpdateSetting(int settingId, string value);
	}
}