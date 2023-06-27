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
        BookStoreOnlineEntities db = new BookStoreOnlineEntities();
        // GET: DetailBook
        public ActionResult Index(int id)
        {
            ViewBag.Book = db.Books.FirstOrDefault(s => s.ID_Book == id);
            return View();
        }


    }
}