using Microsoft.AspNetCore.Mvc;
using Nour_Shop.Models;
using Nour_Shop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.DotNet.MSIdentity.Shared;
using Nancy.Json;
using StackExchange.Redis;

namespace Nour_Shop.Controllers
{
    public class ProductController : Controller
    {
        

		NourShopContext DB = new NourShopContext();
        public IActionResult Index()
        {
			return View();
        }


		public IActionResult ProductList(int currentUser, bool LoginNotOrder)
        {
            if (LoginNotOrder)
			{
				//saving user

				OrderDetails order = new OrderDetails();
                order.Uid = currentUser;
				var serializedObject = JsonSerializer.Serialize(order);
				HttpContext.Session.SetString("order", serializedObject);



				//var orderDet = HttpContext.Session.GetString("order");
				//JavaScriptSerializer jss = new JavaScriptSerializer();
				//OrderDetails OrderDetails = jss.Deserialize<OrderDetails>(orderDet);
				//order.Uid = currentUser;

			}

			List<Product> products = DB.Products.ToList();
            List<Products> vm = new List<Products>();
            foreach (Product product in products)
            {
                Products pro = new Products();
                pro.Name = product.Name;
                pro.Description = product.Description;
                pro.Price = product.Price;
                pro.Catogary = product.Catogary;
                pro.Brand = product.Brand;
                pro.Id = product.Id;
                pro.Status = product.Status;
                pro.Image = product.Image;
                pro.ImageData = product.ImageData;
                pro.Discount = product.Discount;
                vm.Add(pro);
            }


            //code for passing the order number
			int? orderItmsNum = 0;
			orderItmsNum = HttpContext.Session.GetInt32("orderedCount");
            if (orderItmsNum == null)
            {
                orderItmsNum = 0;
            }
            ViewData["orderedCount"] = orderItmsNum;

			return View(vm);
        }
        public IActionResult ProductDetails(int id) {

         
			Product product = DB.Products.Find(id);
            OrderDetails vm = new OrderDetails();
            vm.bought = false;
            vm.product.Id = id;
            vm.CurrentPID = id;
            vm.product.Name = product.Name;
            vm.product.Status = product.Status;
            vm.product.Image = product.Image;
            vm.product.ImageData = product.ImageData; 
            vm.product.Discount = product.Discount;
            vm.product.Description = product.Description;
            vm.product.Price = product.Price;
            vm.product.Catogary=product.Catogary;
            vm.product.Brand = product.Brand;


			//code for passing the order number
			int? orderItmsNum = 0;
			orderItmsNum = HttpContext.Session.GetInt32("orderedCount");
			if (orderItmsNum == null)
			{
				orderItmsNum = 0;
			}
			ViewData["orderedCount"] = orderItmsNum;

			return View("ProductDetails",vm);
        }
        [HttpPost]
		public IActionResult AddToCart(OrderDetails recievedOrder)
		{
            //getting save order
            if (recievedOrder.CurrentCount==0)
            {
                return RedirectToAction("ProductList", "Product", false);
            }
            var orderDet = HttpContext.Session.GetString("order");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            OrderDetails OrderDetails = jss.Deserialize<OrderDetails>(orderDet);

            //if the product is repeated
            var orderedCount = HttpContext.Session.GetInt32("orderedCount");
            int i = 99999;


            foreach (int Id in OrderDetails.Pid)
            {
                if (recievedOrder.CurrentPID == Id)
                {
                     i =OrderDetails.Pid.IndexOf(Id);
                    orderedCount -= OrderDetails.Count[i];
                }
            }
            if (i != 99999)
            {
                OrderDetails.Pid.RemoveAt(i);
                OrderDetails.Count.RemoveAt(i);
            }



            OrderDetails.Pid.Add(recievedOrder.CurrentPID);
			OrderDetails.Count.Add(recievedOrder.CurrentCount);

			var serializedObject = JsonSerializer.Serialize(OrderDetails);
			HttpContext.Session.SetString("order", serializedObject);

            orderedCount = recievedOrder.CurrentCount + orderedCount ?? recievedOrder.CurrentCount;

            HttpContext.Session.SetInt32("orderedCount", orderedCount ?? recievedOrder.CurrentCount);
			return RedirectToAction("ProductList", "Product", false);
		}

        public IActionResult Cart()
        {
            var orderDet = HttpContext.Session.GetString("order");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            OrderDetails vm = jss.Deserialize<OrderDetails>(orderDet);

            foreach (int id in vm.Pid)
            {
                Product product = DB.Products.Find(id);
                vm.bought = true;
                vm.Orderedproducts.Add(product);

            }

            vm.CurrentCount = HttpContext.Session.GetInt32("orderedCount")??0;


            return View(vm);
        }
        public IActionResult Order(int paymentint) {

            var orderDet = HttpContext.Session.GetString("order");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            OrderDetails vm = jss.Deserialize<OrderDetails>(orderDet);


            int i = 0;

            foreach (int id in vm.Pid)
            {
                Nour_Shop.Models.Order newOrder = new Nour_Shop.Models.Order();
                Product product = DB.Products.Find(id);
                newOrder.OrderDate = DateTime.Now;
                newOrder.Uid = vm.Uid;
                newOrder.Pid = id;
                newOrder.Times = vm.Count[i];
                newOrder.Payment = paymentint;
                newOrder.Status = "requested";
                newOrder.Products.Add(product);
                newOrder.UidNavigation = DB.Users.Find(vm.Uid);
                DB.Orders.Add(newOrder);
                DB.SaveChanges();
                i++;

            }

            return RedirectToAction("ProductList", "product", false);
        }



    }

}
