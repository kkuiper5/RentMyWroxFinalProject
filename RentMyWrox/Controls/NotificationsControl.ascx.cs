using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentMyWrox.Models;

namespace RentMyWrox.Controls
{
	public partial class NotificationsControl : System.Web.UI.UserControl
	{
		public enum DisplayType
		{
			AdminOnly,
			NonAdminOnly,
			Both
		}

		public DisplayType Display { get; set; }

		public DateTime? DateForDisplay { get; set; }

		private int numberToSkip;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!DateForDisplay.HasValue)
			{
				DateForDisplay = DateTime.Now;
			}

			if (!IsPostBack)
			{
				numberToSkip = 0;
				DisplayInformation();
			}
			else
			{
				numberToSkip = int.Parse(hfNumberToSkip.Value);
			}
		}

		private void DisplayInformation()
		{
			hfNumberToSkip.Value = numberToSkip.ToString();

			using (RentMyWroxContext context = new RentMyWroxContext())
			{
				var notes = context.Notifications
					.Where(x => x.DisplayStartDate <= DateForDisplay.Value
					            && x.DisplayEndDate >= DateForDisplay.Value);

				if (Display != null && Display != DisplayType.Both)
				{
					notes = notes.Where(x => x.IsAdminOnly ==
					                         (Display == DisplayType.AdminOnly));
				}

				// rolls over the list if it goes past the max number
				if (numberToSkip == notes.Count())
				{
					numberToSkip = 0;
				}

				lbPrevious.Visible = numberToSkip > 0;
				lbNext.Visible = numberToSkip != notes.Count() - 1;

				Notification note = notes.OrderByDescending(x => x.CreateDate)
					.Skip(numberToSkip).FirstOrDefault();

				if (note != null)
				{
					NotificationTitle.Text = note.Title;
					NotificationDetail.Text = note.Details;
				}
			}
		}

		protected void Previous_Click(object sender, EventArgs e)
		{
			numberToSkip--;
			DisplayInformation();
		}

		protected void Next_Click(object sender, EventArgs e)
		{
			numberToSkip++;
			DisplayInformation();
		}

		protected void Notifications_Tick(object sender, EventArgs e)
		{
			numberToSkip++;
			DisplayInformation();
		}
	}
}