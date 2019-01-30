using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentMyWrox.Models
{
	public class OrderDetail
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public Item Item { get; set; }

		[Required]
		[Range(1, 100)]
		public int Quantity { get; set; }

		public Double PricePaidEach { get; set; }
	}
}