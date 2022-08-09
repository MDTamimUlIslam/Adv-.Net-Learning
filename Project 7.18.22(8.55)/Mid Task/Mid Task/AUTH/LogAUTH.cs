using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mid_Task.AUTH
{
    public class LogAUTH : AuthorizeAttribute
    {
      
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authenticated = base.AuthorizeCore(httpContext);
            if (!authenticated)
            {
                return false;
            }
            if (httpContext.Session["ID"] != null)
            {
                return true;
            }
            return false;
        }
    }
}
