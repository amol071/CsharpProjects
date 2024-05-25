using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Godrejite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            if (httpException != null)
            {
                var routeData = new RouteData();
                routeData.Values["controller"] = "Error";
                routeData.Values["namespace"] = "Godrejite.Controllers.Error";

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        routeData.Values["action"] = "NotFound";
                        break;

                    default:
                        routeData.Values["action"] = "General";
                        break;
                }

                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                IController errorController = new Godrejite.Controllers.Error.ErrorController();
                var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
                errorController.Execute(rc);
            }
        }
    }
}