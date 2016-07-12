using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concerti.Website.Areas.Admin.Controllers
{
    public class BlogPostsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}