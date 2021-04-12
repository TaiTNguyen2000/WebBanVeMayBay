using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Website_BanVeMayBay.Models;

namespace Website_BanVeMayBay.Controllers
{
    public class AuthorizationController : AuthorizeAttribute
    {
        public int[] CurrentRole { get; set; }
        public AuthorizationController(int[] role) : base()
        {
            CurrentRole = role;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["TaiKhoan"] == null)
                return base.AuthorizeCore(httpContext);
            NguoiDung user = (NguoiDung)httpContext.Session["TaiKhoan"];
            if (CurrentRole.Contains(user.Quyen))
            {
                return true;
            }
            return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                    new RouteValueDictionary
                                    {
                                        {"action","Index" },
                                        {"controller","Home" }
                                    });
        }
    }
}