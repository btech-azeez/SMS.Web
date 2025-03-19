using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class AllowAnonymousAttribute : Attribute { }

    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionDescriptor = filterContext.ActionDescriptor;
            if (actionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Length > 0)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            if (Session["UserId"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}