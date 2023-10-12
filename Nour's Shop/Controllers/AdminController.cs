using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nour_Shop.Models;
using System.Collections.Generic;
using Nour_Shop.ViewModels;
using System.Net.Http.Headers;

namespace Nour_Shop.Controllers
{
    public class AdminController : Controller
    {
        NourShopContext DB=new NourShopContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminProductList()
        {
            List<Product> products=DB.Products.ToList();
            List<Products> vm=new List<Products>();
            foreach (Product product in products)
            {
                Products pro=new Products();
                pro.Name = product.Name;
                pro.Description = product.Description;
                pro.Price = product.Price;
                pro.Catogary = product.Catogary;
                pro.Brand = product.Brand;
                pro.Id = product.Id;                
                pro.Status = product.Status;
                pro.Image=product.Image;
                pro.ImageData = product.ImageData;
                pro.Discount = product.Discount;
                vm.Add(pro);
            }

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult>  AddProduct(Products newProduct)
        {
            Product DBProduct = new Product();

            
            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                await newProduct.ImageFile.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }
            DBProduct.ImageData=imageData;


            DBProduct.Name = newProduct.Name;
            DBProduct.Description = newProduct.Description;
            DBProduct.Price = newProduct.Price;
            DBProduct.Image = newProduct.Image;
            DBProduct.Status = newProduct.Status;
            DBProduct.Discount = newProduct.Discount;
            DBProduct.Brand = newProduct.Brand;
            DBProduct.Catogary= newProduct.Catogary;
            DB.Products.Add(DBProduct);
            DB.SaveChanges();

            return RedirectToAction("AdminProductList");
        }
        
             public IActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        [HttpGet]
        public IActionResult EditPage(int id)
        {
            Products vm = new Products();
            Product proDB = DB.Products.Find(id);
            vm.Price=proDB.Price;
            vm.Discount=proDB.Discount;
            vm.Brand=proDB.Brand;
            vm.ImageData = proDB.ImageData;
            vm.Name = proDB.Name;
            vm.Id= id;
            vm.Description = proDB.Description;
            vm.Catogary=proDB.Catogary;
            vm.Image = proDB.Image;
            vm.Status = proDB.Status;
            return View("Edit", vm);
        }
        public async Task<IActionResult> Edit(Products oldData)
        {
            Product DBProduct = new Product();


            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                await oldData.ImageFile.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }
            DBProduct.ImageData = imageData;


            DBProduct.Name = oldData.Name;
            DBProduct.Description = oldData.Description;
            DBProduct.Price = oldData.Price;
            DBProduct.Image = oldData.Image;
            DBProduct.Status = oldData.Status;
            DBProduct.Discount = oldData.Discount;
            DBProduct.Brand = oldData.Brand;
            DBProduct.Catogary = oldData.Catogary;
            DB.Products.Update(DBProduct);
            DB.SaveChanges();

            return RedirectToAction("AdminProductList");
        }
   
        public IActionResult Delete(int id)
        {
            Product proDB = DB.Products.Find(id);
            DB.Products.Remove(proDB);
            DB.SaveChanges();
            return RedirectToAction("AdminProductList");
        }
        public IActionResult AdminOrders()
        {
            List<OrderItem> orderlist=new List<OrderItem>();
            List<Order> DBorderList = DB.Orders.ToList();
            foreach(Order order in DBorderList)
            {
                OrderItem nOrder = new OrderItem();
                nOrder.Id = order.Id;
                Product product = DB.Products.Find(order.Pid);
                User user = DB.Users.Find(order.Uid);

                nOrder.ProductName = product.Name;
                nOrder.Quantity = order.Times;
                nOrder.Mobile = user.Mobile;
                nOrder.Status = order.Status;
                if (order.Payment == 0) {
                    nOrder.Payment = "Cash";
                }
                else
                {
                    nOrder.Payment = "Visa";
                }
                nOrder.UserName = user.UserName;
                nOrder.Address = user.Address;
                nOrder.OrderDate = order.OrderDate;
                orderlist.Add(nOrder);

            }
           
            return View("AdminOrders", orderlist);
        }



    }
}
