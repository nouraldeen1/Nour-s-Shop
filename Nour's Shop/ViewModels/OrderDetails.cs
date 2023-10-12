using Nour_Shop.Models;
using System.Collections.Generic;

namespace Nour_Shop.ViewModels
{
	[Serializable]
	public class OrderDetails
	{
		public int Id { get; set; }
		public int CurrentCount { get; set; }
		public int CurrentPID { get; set; }
		public List<int>? Count {  get; set; }=new List<int>();
		public bool bought {  get; set; }

		public decimal Number { get; set; }

		public string Status { get; set; } = null!;

		public decimal Payment { get; set; }

		public decimal? RemainingTime { get; set; }
		public int? Uid { get; set; }

		public List<int?> Pid { get; set; } = new List<int?>();
		public Product product { get; set; }=new Product();
		public  List<Product> Orderedproducts { get; set; } = new List<Product>();

        public DateTime? OrderDate { get; set; }

		public DateTime? DeliveryDate { get; set; }


	}
}
