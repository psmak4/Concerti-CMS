using Concerti.Website.Areas.Admin.ViewModels.Settings;
using Concerti.Website.Models;
using Concerti.Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Concerti.Website.Areas.Admin.Controllers
{
	[RouteArea("Admin")]
	public class SettingsController : BaseController
	{
		private ISettingService settingsService;

		public SettingsController(ISettingService settingsService)
		{
			if (settingsService == null)
				throw new ArgumentNullException("settingsService");
			this.settingsService = settingsService;
		}

		[Route("settings", Name = "AdminSettingsList")]
		public ActionResult Index()
		{
			var settings = settingsService.GetSettings();

			var homePage = settings.FirstOrDefault(s => s.Name.Equals("Home Page", StringComparison.OrdinalIgnoreCase));
			if (homePage != null)
				homePage.Value = GetHomePageSettingTextValue(homePage);

			return View(settings);
		}

		[Route("settings/{settingId:int}/edit", Name = "AdminSettingEdit")]
		public ActionResult Edit(int settingId)
		{
			var setting = settingsService.GetSetting(settingId);
			if (setting == null)
				return RedirectToRoute("AdminSettingsList");

			var model = new EditViewModel()
			{
				SettingId = setting.SettingId,
				Name = setting.Name,
				Value = setting.Value,
				Options = GetSettingOptions(setting)
			};

			return View(model);
		}

		[Route("settings/{settingId:int}/edit")]
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(EditViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var setting = settingsService.UpdateSetting(model.SettingId, model.Value);
					AddSuccessAlert("Setting updated: " + setting.Name);
					Settings.GetSettings();

					return RedirectToRoute("AdminSettingsList");
				}
				catch (Exception ex)
				{
					AddErrorAlert(ex.Message);
				}
			}

			var editSetting = settingsService.GetSetting(model.SettingId);
			if (editSetting == null)
				return RedirectToRoute("AdminSettingsList");

			model.Name = editSetting.Name;

			return View(model);
		}

		private IEnumerable<SelectListItem> GetSettingOptions(Setting setting)
		{
			var options = new List<SelectListItem>();
			IEnumerable<SettingOption> settingOptions;

			if (setting.Name.Equals("Home Page", StringComparison.OrdinalIgnoreCase))
				settingOptions = settingsService.GetHomePageOptions();
			else
				settingOptions = setting.SettingOptions;

			foreach (var option in settingOptions)
			{
				options.Add(new SelectListItem()
				{
					Text = option.Text,
					Value = option.Value
				});
			}

			return options.AsEnumerable();
		}

		private string GetHomePageSettingTextValue(Setting setting)
		{
			var pageId = int.Parse(string.IsNullOrWhiteSpace(setting.Value) ? "0" : setting.Value);
			return settingsService.GetHomePageSettingTextValue(pageId);
		}
	}
}