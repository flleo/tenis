using Tenis.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;

namespace Tenis.Controllers
{
    internal class AuthorizedFilter : ActionFilterAttribute
    {
        public object Session { get; private set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            User u = filterContext.HttpContext.Session["USUARIO"] as User;
           
            if (u == null)
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "AuthError"
                };
            } else
            {
               
               
            }
        }
    }
}