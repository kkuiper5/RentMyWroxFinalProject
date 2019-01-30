using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace RentMyWrox
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

		void Application_Error(object sender, EventArgs e)
		{
			if (HttpContext.Current.Server.GetLastError() != null)
			{
				Exception myException = HttpContext.Current.Server.GetLastError().GetBaseException();
				//Trace.TraceError(myException.Message);
				//Trace.TraceError(myException.StackTrace);
				ILogger logger = LogManager.GetCurrentClassLogger();
				logger.Error(myException, myException.Message);
			}
		}
    }
}