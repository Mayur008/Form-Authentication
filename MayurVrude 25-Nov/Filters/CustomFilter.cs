using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MayurVrude_25_Nov.Filters
{
    public class CustomFilter : AuthorizeAttribute, IAuthenticationFilter
    {

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //We are checking Result is null or Result is HttpUnauthorizedResult 
            // if yes then we are Redirect to Error View
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
            }
        }  

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get("UserInfo");

            if (cookie == null || cookie["name"] == null || cookie["userid"] == null || cookie["usertype"] == null)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Login/Index.cshtml"
                };
                
            }
        }
    }
}