using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentMyWrox.Models;

namespace RentMyWrox.Admin
{
	public partial class ManageHobby : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void DetailsView1_InsertItem()
		{
			Hobby hobby = new Hobby();
			TryUpdateModel(hobby);
			if (ModelState.IsValid)
			{
				using (RentMyWroxContext context = new RentMyWroxContext())
				{
					context.Hobbies.Add(hobby);
					context.SaveChanges();
				}
			}

		}

		public object DetailsView1_GetItem(int id)
		{
			using (RentMyWroxContext context = new RentMyWroxContext())
			{
				return context.Hobbies.Find(id);
			}
		}
	}
}