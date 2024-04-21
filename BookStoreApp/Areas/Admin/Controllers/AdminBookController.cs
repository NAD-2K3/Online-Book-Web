using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;
using System.IO;


namespace BookStoreApp.Areas.Admin.Controllers
{
    public class AdminBookController : Controller
    {
        private BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1();

        // GET: Admin/Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.BookCategory);
            return View(books.ToList());
        }

        // GET: Admin/Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Admin/Books/Create
        public ActionResult Create()
        {
            ViewBag.Author_ID = new SelectList(db.Authors, "Author_ID", "Name");
            ViewBag.ID_BookCategory = new SelectList(db.BookCategories, "ID_BookCategory", "Name_BookCategory");
            return View();
        }

        // POST: Admin/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase ImageProd, HttpPostedFileBase LinkPDF)
        {
            if (ModelState.IsValid)
            {
                if (ImageProd != null)
                {
                    var fileName = Path.GetFileName(ImageProd.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    book.Image = fileName;
                    ImageProd.SaveAs(path);
                }

                if (LinkPDF != null)
                {
                    var fileName = Path.GetFileName(LinkPDF.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/PDF"), fileName);
                    book.Link = fileName;
                    LinkPDF.SaveAs(path);
                }


                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Author_ID = new SelectList(db.Authors, "Author_ID", "Name", book.Author_ID);
            ViewBag.ID_BookCategory = new SelectList(db.BookCategories, "ID_BookCategory", "Name_BookCategory", book.ID_BookCategory);
            return View(book);
        }

        // GET: Admin/Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Author_ID = new SelectList(db.Authors, "Author_ID", "Name", book.Author_ID);
            ViewBag.ID_BookCategory = new SelectList(db.BookCategories, "ID_BookCategory", "Name_BookCategory", book.ID_BookCategory);
            return View(book);
        }

        // POST: Admin/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Book,Book_Name,Description,Image,PriceImport,PriceHire,DateImport,Chapter,Link,ID_BookCategory,Author_ID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Author_ID = new SelectList(db.Authors, "Author_ID", "Name", book.Author_ID);
            ViewBag.ID_BookCategory = new SelectList(db.BookCategories, "ID_BookCategory", "Name_BookCategory", book.ID_BookCategory);
            return View(book);
        }

        // GET: Admin/Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Report()
        {
            ViewBag.OrderDetail = new List<HireBookDetail>();
            ViewBag.CustomerQuantity = 0;
            ViewBag.BookQuantity = 0;
            ViewBag.MostRentedBook = "";
            return View();
        }

        [HttpPost]
        public ActionResult Report(FormCollection form)
        {
            var dayStart = DateTime.Parse(form["date_start"]);
            var dayEnd = DateTime.Parse(form["date_end"]);
            ViewBag.CustomerQuantity = 0;
            ViewBag.BookQuantity = 0;

            // Lấy danh sách hóa đơn theo ngày
            var orderList = db.HireBooks.Where(s => s.Date_Start >= dayStart && s.Date_Start <= dayEnd && s.Confirm == 1).GroupBy(s => s.User_Name).Count();
            // Lấy danh sách chi tiết hóa đơn theo ngày
            var orderDetailList = db.HireBookDetails.Where(s => s.Date_Start >= dayStart && s.Date_Start <= dayEnd);
            // Lấy ra sách được thuê nhiều nhất trong ngày
            var mostRentedBook = orderDetailList.GroupBy(b => b.ID_Book).OrderByDescending(c => c.Count()).Select(s => s.FirstOrDefault());

            ViewBag.OrderDetail = db.HireBookDetails.Where(s => s.Date_Start >= dayStart && s.Date_Start <= dayEnd).Select(b => b.Book.Book_Name).Distinct();

            ViewBag.MostRentedBook = mostRentedBook.FirstOrDefault().Book.Book_Name;

            ViewBag.CustomerQuantity = orderList;

            // Lấy số lượng sách
            foreach (var item in orderDetailList)
            {
                ViewBag.BookQuantity += 1;
            }

            return View();
        }
    }
}
