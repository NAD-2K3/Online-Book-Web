using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;
using BookStoreApp.Patterns.Iterator;

namespace BookStoreApp.Controllers
{
    public class HomeController : Controller
    {
        //BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1();
        public readonly BookStoreOnlineEntities1 db = SingletonPattern.Instance;
        public ActionResult Index()
        {
            var book = db.Books.FirstOrDefault(s => s.ID_Book == 15);
            Book b2 = book.ShallowCopy();
            ProductsIterator products = new ProductsIterator();

            ViewBag.book2 = b2;
            ViewBag.lstBook = db.Books.ToList();

            return View(products);
        }
    }
}