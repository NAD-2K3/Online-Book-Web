using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;
using BookStoreApp.Patterns.Command;
namespace BookStoreApp.Controllers
{
    public class LoginRegisterController : Controller
    {
        BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1 ();
        // GET: LoginRegister

        public void setAccountInvoker()
        {

        }
        public ActionResult Index()
        {
            return View();  
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer cus)
        {

            //var checkadmin = db.Admins.Where(s => s.User_Name == cus.User_Name && s.Pass_Word == cus.Password).FirstOrDefault();
            //if(checkadmin != null)
            //{
            //    return RedirectToAction("Index", "Admin/AdminHome");

            //}

            Account account = new Account(cus.User_Name, cus.Password);

            ICommand login = new LoginAccount(account);
            ICommand logout = new LogoutAccount(account);
            AccountInvoker accountInvoker = new AccountInvoker(login, logout);

            accountInvoker.clickLoginAccount();
            TempData["AccountInvoker"] = accountInvoker;

            return RedirectToAction("Index", "Home");

            //var checkcus = db.Customers.Where(s => s.User_Name == cus.User_Name && s.Password == cus.Password).FirstOrDefault();


            //if (checkcus == null)
            //{
            //    ViewBag.ErrorInfo = "Sai số điện thoại hoặc mật khẩu";
            //    return View("Login");
            //}
            //else
            //{
            //    db.Configuration.ValidateOnSaveEnabled = false;
            //    Session["User_Name"] = checkcus.User_Name;
            //    Session["Name"] = checkcus.Name;

            //    return RedirectToAction("Index", "Home");
            //}

        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            //Customer cus = new Customer();
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Customer cus)
        {
            if (ModelState.IsValid)
            {
                var director = new AccountDirector();

                var account = director.CreateFullAccount(cus.Name, cus.DOB, cus.Phone_Number, cus.Address, cus.User_Name, cus.Password);

                var check = db.Customers.Where(s => s.User_Name == cus.User_Name).FirstOrDefault();
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Customers.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorRegister = "Tên tài khoản đã tồn tại";
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            AccountInvoker accountInvoker = TempData["AccountInvoker"] as AccountInvoker;
            accountInvoker.clickLogoutAccount();
            return RedirectToAction("Login", "LoginRegister");
        }
    }
}