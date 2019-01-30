using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentMyWrox.Admin
{
	public partial class ItemList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow row = GridView1.SelectedRow;
			string id = row.Cells[1].Text;
			Response.Redirect(@"ManageItem\" + id);
		}
	}
}