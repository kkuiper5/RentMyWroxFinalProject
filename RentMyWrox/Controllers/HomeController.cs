using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentMyWrox.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home/ContactUs
		public ActionResult ContactUs()
		{
			return View();
		}
        
        // GET: Home/About
		public ActionResult About()
		{
			return View();
		}

        // GET: /Home/
	    public ActionResult Index()
	    {
	        return View();
	    }
	}
}