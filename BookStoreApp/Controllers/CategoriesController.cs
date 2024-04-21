using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;
using BookStoreApp.Patterns.FactoryMethod;

namespace BookStoreApp.Controllers
{
    public class CategoriesController : Controller
    {
        BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1();
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialCateHeader()
        {
            ViewBag.CategoryHeader = db.BookCategories.ToList();
            return PartialView();
        }


        public ActionResult GetBookByCategoryID(int id)
        {
            var type = db.BookCategories.FirstOrDefault(c => c.ID_BookCategory == id).Name_BookCategory;
            FactoryCategory factory = new FactoryCategory();
            var listCategory = factory.CreateCategory(type);

            ViewBag.LstProduct = listCategory.listBookByCategory(id);

            ViewBag.CategoryName = db.BookCategories.FirstOrDefault(c => c.ID_BookCategory == id);
            //ViewBag.LstProduct = db.Books.Where(b => b.ID_BookCategory == id).ToList();
            return View();
        }

        public ActionResult PartialCategory()
        {
            ViewBag.CategoryList = db.BookCategories.ToList();
            return PartialView();
        }


        public ActionResult SearchBook(string search_key)
        {
            @ViewBag.SearchKey = search_key;
            ViewBag.LstProduct = db.Books.Where(b => b.Book_Name.Contains(search_key)).ToList(); 
            return View();
        }
    }
}