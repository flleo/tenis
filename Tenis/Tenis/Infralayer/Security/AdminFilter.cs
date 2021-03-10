using Tenis.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;

namespace Tenis.Controllers
{
    internal class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User u = null;
            Boolean auth = HttpContext.Current.User.Identity.IsAuthenticated;

            if (filterContext.HttpContext.Session["USUARIO"] is User)
                u = filterContext.HttpContext.Session["USUARIO"] as User;
            if (auth && u == null) FormsAuthentication.RedirectToLoginPage();
            if (u == null || u.idTipoUsuario != 1)
            {
                filterContext.HttpContext.Session.Abandon();
                filterContext.Result = new ViewResult()
                {
                    ViewName = "AuthError"
                };
            }
        }
    }
}