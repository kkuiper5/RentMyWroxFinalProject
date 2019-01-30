using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentMyWrox;
using Microsoft.AspNet.FriendlyUrls;
using RentMyWrox.Models;

namespace RentMyWrox.Admin
{
	public partial class ManageItem : WebFormsBaseClass
	{
		private int itemId;

		protected void Page_Load(object sender, EventArgs e)
		{
			IList<string> segments = Request.GetFriendlyUrlSegments();
			itemId = 0;
			if (segments != null && segments.Count > 0)
			{
				int.TryParse(segments[0], out itemId);
			}

			if (!IsPostBack && itemId != 0)
			{
				using (RentMyWroxContext context = new RentMyWroxContext())
				{
					var item = context.Items.FirstOrDefault(x => x.Id == itemId);
					tbAcquiredDate.Text = item.DateAcquired.ToShortDateString();
					tbCost.Text = item.Cost.ToString();
					tbDescription.Text = item.Description;
					tbItemNumber.Text = item.ItemNumber;
					tbName.Text = item.Name;
				}
			}
		}

		protected void SaveItem_Clicked(object sender, EventArgs e)
		{
			if (IsValid)
			{
				Item item;
				using (RentMyWroxContext context = new RentMyWroxContext())
				{
					if (itemId == 0)
					{
						item = new Item();
						UpdateItem(item);
						context.Items.Add(item);
					}
					else
					{
						item = context.Items.FirstOrDefault(x => x.Id == itemId);
						UpdateItem(item);
					}
					context.SaveChanges();
				}
				Response.Redirect("~/admin/ItemList");
			}
		}

		private void UpdateItem(Item item)
		{
			double cost;
			double.TryParse(tbCost.Text, out cost);
			item.Cost = cost;

			DateTime acqDate = DateTime.Now;
			DateTime.TryParse(tbAcquiredDate.Text, out acqDate);
			item.DateAcquired = acqDate;

			item.Description = tbDescription.Text;
			item.Name = tbName.Text;
			item.ItemNumber = tbItemNumber.Text;
			item.IsAvailable = true;

			if (fuPicture.PostedFile != null && fuPicture.HasFile)
			{
				Guid newPrefix = Guid.NewGuid();
				string localDir = Path.Combine("ItemImages", newPrefix + "_" + fuPicture.FileName);
				string fullPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, localDir);
				fuPicture.SaveAs(fullPath);
				item.Picture = "/" + localDir.Replace("\\", "/");
			}
		}
	}
}