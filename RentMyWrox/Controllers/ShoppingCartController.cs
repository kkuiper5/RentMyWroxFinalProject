using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentMyWrox.Models;

namespace RentMyWrox.Controllers
{
	public class ShoppingCartController : Controller
	{
		// GET: ShoppngCart
		public ActionResult Index()
		{
			using (RentMyWroxContext context = new RentMyWroxContext())
			{
				ShoppingCartSummary summary = GetShoppingCartSummary(context);
				return PartialView("_ShoppingCartSummary", summary);
			}
		}

		public ActionResult AddToCart(int id)
		{
			Guid UserID = UserHelper.GetUserId();
			using (RentMyWroxContext context = new RentMyWroxContext())
			{
				Item addedItem = context.Items.FirstOrDefault(x => x.Id == id);

				// now that we know it is a valid ID
				if (addedItem != null)
				{
					// Check to see if this item was already added
					var sameItemInShoppingCart =
						context.ShoppingCarts.FirstOrDefault(x => x.Item.Id == id && x.UserId == UserID);
					if (sameItemInShoppingCart == null)
					{
						// if not already in shopping cart then add it
						ShoppingCart sc = new ShoppingCart
						{
							Item = addedItem,
							UserId = UserID,
							Quantity = 1,
							DateAdded = DateTime.Now
						};
						context.ShoppingCarts.Add(sc);
					}
					else
					{
						// increment the quantity of the existing shopping cart item
						sameItemInShoppingCart.Quantity++;
					}

					context.UserVisits.Add(
						new UserVisit
						{
							ItemId = id,
							UserId = UserID,
							VisitDate = DateTime.UtcNow
						});
					//UserHelper.AddUserVisit(id, context);
					context.SaveChanges();
				}

				ShoppingCartSummary summary = GetShoppingCartSummary(context);
				return PartialView("_ShoppingCartSummary", summary);
			}
		}

		private ShoppingCartSummary GetShoppingCartSummary(RentMyWroxContext context)
		{
			Guid UserId = UserHelper.GetUserId();

			ShoppingCartSummary summary = new ShoppingCartSummary();

			var cartList = context.ShoppingCarts.Where(x => x.UserId == UserId);
			if (cartList != null && cartList.Count() > 0)
			{
				summary.TotalValue = cartList.Sum(x => x.Quantity * x.Item.Cost);
				summary.Quantity = cartList.Sum(x => x.Quantity);
			}

			var appUser = UserHelper.GetApplicationUser();
			if (appUser != null)
			{
				summary.UserDisplayName = $"{appUser.FirstName} {appUser.LastName}";
			}

			return summary;
		}

		[Authorize]
		[HttpGet]
		public ActionResult Checkout()
		{
			Guid UserID = UserHelper.GetUserId();
			ViewBag.ApplicationUser = UserHelper.GetApplicationUser();
			ViewBag.AmCheckingOut = true;
			using (RentMyWroxContext context = new RentMyWroxContext())
			{
				var shoppingCartItems = context.ShoppingCarts.Include("Item").Where(x => x.UserId == UserID);

				Order newOrder = new Order
				{
					OrderDate = DateTime.Now,
					PickupDate = DateTime.Now.Date,
					UserId = UserID,
					OrderDetails = new List<OrderDetail>()
				};
				foreach (var item in shoppingCartItems)
				{
					OrderDetail od = new OrderDetail
					{
						Item = item.Item,
						PricePaidEach = item.Item.Cost,
						Quantity = item.Quantity
					};
					newOrder.OrderDetails.Add(od);
				}
				return View("Details", newOrder);
			}
		}

		[Authorize]
		[HttpPost]
		public ActionResult Checkout(Order order)
		{
			Guid UserID = UserHelper.GetUserId();
			ViewBag.ApplicationUser = UserHelper.GetApplicationUser();
			using (RentMyWroxContext context = new RentMyWroxContext())
			{
				var shoppingCartItems = context.ShoppingCarts.Include("Item").Where(x => x.UserId == UserID);
				order.OrderDetails = new List<OrderDetail>();
				order.UserId = UserID;
				order.OrderDate = DateTime.Now;
				foreach (var item in shoppingCartItems)
				{
					//int quantity = 0;
					//int.TryParse(Request.Form.Get(item.Item.Id.ToString()), out quantity);
					//if (quantity > 0)
					//{
					//	OrderDetail od = new OrderDetail
					//	{
					//		Item = item.Item,
					//		PricePaidEach = item.Item.Cost,
					//		Quantity = quantity
					//	};
					//	order.OrderDetails.Add(od);
					//}
					OrderDetail od = new OrderDetail
					{
						Item = item.Item,
						PricePaidEach = item.Item.Cost,
						Quantity = item.Quantity
					};
					order.OrderDetails.Add(od);
				}
				order = context.Orders.Add(order);
				context.ShoppingCarts.RemoveRange(shoppingCartItems);
				context.SaveChanges();
				return RedirectToAction("Details", "Order", new { id = order.Id });
			}
		}
	}
}