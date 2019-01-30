using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentMyWrox.Models
{
	public class ShoppingCart
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public Item Item { get; set; }
		[Required]
		public Guid UserId { get; set; }
		[Required]
		[Range(1, 100)]
		public int Quantity { get; set; }
		[Required]
		public DateTime DateAdded { get; set; }
	}
}