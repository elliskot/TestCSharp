using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestCSharp.Models.Entities;
using TestCSharp.WebSite.Base.DataAccess;

namespace TestCSharp.WebSite.Base.Controllers
{
    public abstract class WebsiteContextController : Controller
    {
        private WebDatabaseFactory _oDBFactory;
        protected WebDatabaseFactory DatabaseFactory
        {
            get { return _oDBFactory; }
        }

        public WebsiteContextController()
            : base()
        {
            _oDBFactory = new WebDatabaseFactory(TestCSharpContext.Name);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.BackUrl = GetBackUrl();
            base.OnActionExecuting(filterContext);
        }

        protected override void Dispose(bool disposing)
        {
            _oDBFactory.Dispose();
            base.Dispose(disposing);
        }

        public string GetBackUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["BackUrl"]))
            {
                return Request.QueryString["BackUrl"];
            }
            else if (Request.Params["BackUrl"] != null)
            {
                return Request.Params["BackUrl"];
            }
            else if (Request.UrlReferrer != null)
            {
                return Request.UrlReferrer.ToString();
            }
            return "";
        }

    }
}
