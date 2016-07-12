namespace Concerti.Website.Areas.Admin.Models
{
	public class Alert
	{
		public const string TempDataKey = "Alerts";
		public string AlertType { get; set; }
		public string Message { get; set; }
		public bool Dismissable { get; set; }
	}

	public class AlertTypes
	{
		public const string Error = "error";
		public const string Information = "info";
		public const string Success = "success";
	}
}