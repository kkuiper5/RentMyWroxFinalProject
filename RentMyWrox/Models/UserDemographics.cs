using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentMyWrox.Models
{
	public class UserDemographics
	{
		public UserDemographics()
		{
			Hobbies = new List<Hobby>();
			Birthdate = new DateTime(1900, 1, 1);
			DateMovedIntoArea = new DateTime(1900, 1, 1);
			//{ "Gardening", "Reading", "Games", "Dining Out", "Sports", "Other" };
		}

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Please tell us your birth date")]
		//[Range(typeof(DateTime), "1/1/1900", "12/31/2013", ErrorMessage = "{0} must be between {1} and {2}")]
		public DateTime Birthdate { get; set; }

		public string Gender { get; set; }

		[Display(Name = "Marital status")]
		[Required(ErrorMessage = "Please tell us your marital status")]
		//[StringLength(15, MinimumLength = 2)]
		//[RegularExpression(@"^(?:.*[a-x]){2,15}
		public string MaritalStatus { get; set; }

		[Display(Name = "Date you moved into area")]
		[Required(ErrorMessage = "Please tell us when you moved into the area")]
		//[Range(typeof(DateTime), "1/1/1900", "12/31/2023", ErrorMessage = "Your response must be between {1} and {2}")]
		public DateTime DateMovedIntoArea { get; set; }

		public bool OwnHome { get; set; }

		[Display(Name = "How many people live in your house?")]
		[Required(ErrorMessage = "Please tell us how many live in your home")]
		[Range(typeof(int), "1", "99", ErrorMessage = "Total must be between {1} and {2}")]
		public int TotalPeopleInHome { get; set; }

		public virtual List<Hobby> Hobbies { get; set; }
	}
}