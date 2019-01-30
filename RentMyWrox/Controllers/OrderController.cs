using RentMyWrox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace RentMyWrox.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Details(int id)
		{
			Guid UserID = UserHelper.GetUserId();
			ViewBag.ApplicationUser = UserHelper.GetApplicationUser();
			using (RentMyWroxContext context = new RentMyWroxContext())
			{
				var order = context.Orders.Include(p => p.OrderDetails.Select(c => c.Item))
					.FirstOrDefault(x => x.Id == id && x.UserId == UserID);
				return View(order);
			}
		}
    }
}