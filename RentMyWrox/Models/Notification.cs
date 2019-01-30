using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentMyWrox.Models
{
	public class Notification
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(50)]
		public string Title { get; set; }

		[MaxLength(750)]
		public string Details { get; set; }

		public bool IsAdminOnly { get; set; }

		public DateTime DisplayStartDate { get; set; }

		public DateTime DisplayEndDate { get; set; }
		
		public DateTime CreateDate { get; set; }
	}
}