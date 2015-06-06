using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JCSJWCF
{
    public class DynamicPassHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(System.Web.HttpContext.Current.Application["DTMM"].ToString());
        }
    }
}