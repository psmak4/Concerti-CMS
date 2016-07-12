using Concerti.Website.Core.User;
using System.Web.Mvc;

namespace Concerti.Website.Views
{
	public abstract class BaseViewPage : WebViewPage
	{
		public virtual new CustomPrincipal User
		{
			get { return base.User as CustomPrincipal; }
		}
	}

	public abstract class BaseViewPage<T> : WebViewPage<T>
	{
		public virtual new CustomPrincipal User
		{
			get { return base.User as CustomPrincipal; }
		}
	}
}