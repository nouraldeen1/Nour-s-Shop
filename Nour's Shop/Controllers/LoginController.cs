using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nour_Shop.Controllers;
using Nour_Shop.Models;
using Nour_Shop.ViewModels;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;

namespace Nour_s_Shop.Controllers
{
    public class LoginController : Controller
    {
        NourShopContext DB=new NourShopContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult registeration()
        {
            return View();
        }
        [HttpGet]
        public IActionResult registeration(signUp user)
        {
            User userdb = new User();
            if (user.age > 0)
            {
                //userdb.Age = user.Age;
                userdb.Email = user.Email;
                userdb.FirstName = user.FirstName;
                userdb.LastName = user.LastName;
                userdb.Address = user.Address;
                userdb.UserName = user.UserName;
                userdb.age = user.age;
                userdb.Mobile = user.Mobile;
                userdb.Password = user.Password;
                userdb.Sex = user.Sex;
        
                DB.Users.Add(userdb);
                DB.SaveChanges();
            }


            return View("Registeration");
        }
        [HttpGet]
        public IActionResult LoginCheck(signUp user)
        {
            string email= user.Email;
            string password=user.Password;
            //String targetedpassword = "from users in DB.Users where users.Email == email select password";
            //var query1 = from b in DB.Users
            //             where email == b.Email
            //             select b;
            User userDB = DB.Users.FirstOrDefault(E => E.Email == email.ToString());
           // String targetedpassword=query1.ToString();
            //DB.FromExpression("Use [Nour Shop]\r\nselect ID\r\nfrom Users u\r\nwhere u.email ='nour.hassan1321@gmail.com'")
            if (userDB != null && userDB.Password ==password)
            {
                if (email == "nour.hassan1321@gmail.com")
                {
                    return RedirectToAction("AdminProductList", "Admin");

                }
            }

            return RedirectToAction("ProductList", "Product",new { currentUser = userDB.Id,  LoginNotOrder = true });

        }

       
    }

    
}
