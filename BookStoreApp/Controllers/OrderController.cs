using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class OrderController : Controller
    {
        BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1();
        // GET: Order

        public ActionResult OrderList(FormCollection user)
        {
            string userName = user["user_name"];
            //ViewBag.strName = Convert.ToString(name);    
            ViewBag.OrderList = db.HireBooks.Where(s => s.User_Name == userName).ToList();
            return View();
        }

        //public ActionResult OrderList()
        //{
        //    ViewBag.OrderList = db.HireBooks.ToList();
        //    return View();
        //}
        public ActionResult Details(int id)
        {
            ViewBag.OrderDetail = db.HireBookDetails.Where(s => s.ID_HireBook == id).ToList();
            return View();
        }

        public ActionResult HistoryOrderConfirm(int id)
        {
            ViewBag.HistoryOrder = db.HireBookDetails.Where(s => s.ID_HireBook == id).ToList();
            return View();
        }
    }
}