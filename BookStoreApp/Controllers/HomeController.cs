using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class HomeController : Controller
    {
        BookStoreOnlineEntities db = new BookStoreOnlineEntities();
        public ActionResult Index()
        {
            

            ViewBag.lstBook = db.Books.ToList();
            return View();
        }

        
    }
}