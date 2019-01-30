using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using RentMyWrox.Models;

namespace RentMyWrox.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser()
            {
				FirstName = FirstName.Text,
				LastName = LastName.Text,
	            UserName = Email.Text,
	            Email = Email.Text,
				OrderCount = 0,
				UserDemographicsId = 0,
				Address = new Address()
				{
					Address1 = Address1.Text,
					Address2 = Address2.Text,
					City = City.Text,
					State = State.Text,
					ZipCode = ZipCode.Text
				}
            };
	        Guid oldTemporaryUser = Controllers.UserHelper.GetUserId();
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
				Controllers.UserHelper.TransferTemporaryUserToRealUser(oldTemporaryUser,user.Id);
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
	            Response.Redirect(@"~\UserDemographics\Create?" + Request.QueryString["ReturnUrl"]);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}