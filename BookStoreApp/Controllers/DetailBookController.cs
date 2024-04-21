using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class DetailBookController : Controller
    {
        BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1();
        // GET: DetailBook
        public ActionResult Index(int id)
        {
            var book = db.Books.FirstOrDefault(s => s.ID_Book == id);
            ViewBag.Book = book;
            ViewBag.lstBook = db.Books.Where(b => b.ID_BookCategory == book.ID_BookCategory).ToList().Take(4);
            return View();
        }


    }
}