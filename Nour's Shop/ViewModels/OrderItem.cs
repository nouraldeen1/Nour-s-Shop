using Nour_Shop.Models;

namespace Nour_Shop.ViewModels
{
    public class OrderItem
    {
        
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string Mobile { get; set; }

        public int? Quantity { get; set; }

        public string Status { get; set; } = null!;

        public string Payment { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }

        public string City { get; set; }



        public DateTime? OrderDate { get; set; }



    }

}
