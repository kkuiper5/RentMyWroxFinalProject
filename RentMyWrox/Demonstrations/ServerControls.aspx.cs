using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentMyWrox.Demonstrations
{
    public partial class ServerControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ListItem> colorsList = new List<ListItem>();
                colorsList.Add(new ListItem { Text = "Red", Value = "red" });
                colorsList.Add(new ListItem { Text = "Green", Value = "green" });
                colorsList.Add(new ListItem { Text = "Blue", Value = "blue" });
                availableColors.DataSource = colorsList;
                availableColors.DataBind();
            }

            htmlText.Value = "test this";
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = demoToolBox.Text;  // set the text of the label to the text from the text box
            demoToolBox.Text = string.Empty; // empty the text box

List<string> selectedColors = new List<string>();
foreach(ListItem item in availableColors.Items)
{
    if (item.Selected)
    {
        selectedColors.Add(item.Value);
    }
}
        }
    }
}