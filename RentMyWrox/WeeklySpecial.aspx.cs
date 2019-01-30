using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentMyWrox
{
	public partial class WeeklySpecial : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			int specialItemId = 2;
			//Response.Redirect("Items/Details/" + specialItemId);
			Server.TransferRequest("Item/Details/" + specialItemId);
		}
	}
}