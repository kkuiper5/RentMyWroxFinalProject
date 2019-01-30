using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentMyWrox.Models
{
	public class UserVisit
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public Guid UserId { get; set; }

		[Required]
		public int ItemId { get; set; }

		[Required]
		public DateTime VisitDate { get; set; }
	}
}