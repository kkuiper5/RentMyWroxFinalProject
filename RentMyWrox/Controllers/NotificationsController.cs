using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentMyWrox.Models;

namespace RentMyWrox.Controllers
{
    public class NotificationsController : Controller
    {
	    [OutputCache(Duration = 3600)]
	    public ActionResult AdminSnippet()
	    {
		    using (RentMyWroxContext context = new RentMyWroxContext())
		    {
			    Notification note = context.Notifications
				    .Where(x => x.DisplayStartDate <= DateTime.Now
				                && x.DisplayEndDate >= DateTime.Now
				                && x.IsAdminOnly)
				    .OrderByDescending(x => x.CreateDate)
				    .FirstOrDefault();
			    return PartialView("_Notification", note);
		    }
	    }
	    [OutputCache(Duration = 3600)]
	    public ActionResult NonAdminSnippet()
	    {
		    using (RentMyWroxContext context = new RentMyWroxContext())
		    {
			    Notification note = context.Notifications
				    .Where(x => x.DisplayStartDate <= DateTime.Now
				                && x.DisplayEndDate >= DateTime.Now
				                && !x.IsAdminOnly)
				    .OrderByDescending(x => x.CreateDate)
				    .FirstOrDefault();
			    return PartialView("_Notification", note);
		    }
	    }
	}
}