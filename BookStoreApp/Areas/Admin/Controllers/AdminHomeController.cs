using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1();
        // GET: Admin/AdminHome
        //Lọc theo trạng thái
        public ActionResult Index()
        {
            IEnumerable<HireBook> lsthirebook = db.HireBooks.ToList().OrderByDescending(n => n.ID_HireBook);
            ViewBag.lst = lsthirebook;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection state)
        {
            var i = int.Parse(state["state"]);

            if (i == 1)
            {
                IEnumerable<HireBook> lsthirebook = db.HireBooks.Where(s => s.Confirm == 0).ToList().OrderByDescending(n => n.ID_HireBook);
                ViewBag.lst = lsthirebook;
            }
            else if (i == 2)
            {
                IEnumerable<HireBook> lsthirebook = db.HireBooks.Where(s => s.Confirm == 1).ToList().OrderByDescending(n => n.ID_HireBook);
                ViewBag.lst = lsthirebook;
            }
            else
            {
                IEnumerable<HireBook> lsthirebook = db.HireBooks.ToList().OrderByDescending(n => n.ID_HireBook);
                ViewBag.lst = lsthirebook;
            }
            return View();
        }
        //Lọc theo tên
        public ActionResult FillName()
        {
            IEnumerable<HireBook> lsthirebook = db.HireBooks.ToList().OrderByDescending(n => n.ID_HireBook);
            ViewBag.lst = lsthirebook;
            return View();
        }

        [HttpPost]
        public ActionResult FillName(FormCollection state)
        {
            var name = state["name"].ToString();

            IEnumerable<HireBook> lsthirebook = db.HireBooks.Where(s => s.Customer.Name.Contains(name)).ToList().OrderByDescending(n => n.ID_HireBook);
            ViewBag.lst = lsthirebook;


            return View();
        }

        //Lọc theo ngày
        public ActionResult FillDate()
        {
            IEnumerable<HireBook> lsthirebook = db.HireBooks.ToList().OrderByDescending(n => n.ID_HireBook);
            ViewBag.lst = lsthirebook;


            return View();
        }
        [HttpPost]
        public ActionResult FillDate(FormCollection state)
        {
            var date = DateTime.Parse(state["dayStart"]);

            IEnumerable<HireBook> lsthirebook = db.HireBooks.Where(s => s.Date_Start == date).ToList().OrderByDescending(n => n.ID_HireBook);
            ViewBag.lst = lsthirebook;


            return View();
        }

        //Xác nhận đã thanh toán cho người dùng
        public ActionResult Confirm(int i)
        {
            //Xác nhận rằng đơn hàng đã được thanh toán
            HireBook hireBook = db.HireBooks.Where(s => s.ID_HireBook == i).FirstOrDefault();
            hireBook.Confirm = 1;

            //Tiến hành cập nhật ngày bắt đầu và ngày kết thúc cho chi tiết đơn hàng
            List<HireBookDetail> lst = db.HireBookDetails.Where(s => s.ID_HireBook == i).ToList();
            foreach (HireBookDetail item in lst)
            {
                item.Date_Start = DateTime.Now;
                int day_package = db.Packages.Where(s => s.ID_Package == item.Day_Limit).FirstOrDefault().Day_Limit;
                item.Date_End = DateTime.Now.AddDays(day_package);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Admin/AdminHome");
        }
        //Hủy Xác nhận đã thanh toán cho người dùng
        public ActionResult Cancle(int i)
        {
            //Xác nhận rằng đơn hàng đã được thanh toán
            HireBook hireBook = db.HireBooks.Where(s => s.ID_HireBook == i).FirstOrDefault();
            hireBook.Confirm = 2;

            //Tiến hành cập nhật ngày bắt đầu và ngày kết thúc cho chi tiết đơn hàng
            List<HireBookDetail> lst = db.HireBookDetails.Where(s => s.ID_HireBook == i).ToList();
            foreach (HireBookDetail item in lst)
            {
                item.Date_Start = null;
                int day_package = db.Packages.Where(s => s.ID_Package == item.Day_Limit).FirstOrDefault().Day_Limit;
                item.Date_End = null;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Admin/AdminHome");
        }


        //////////////////////////////////////////////QUẢN LÝ HỦY SÁCH
        // Danh sách các sách đang có hiệu lực 

        //Lọc theo tên KH
        public ActionResult CancelHireBook()
        {
            IEnumerable<HireBookDetail> lst = db.HireBookDetails.ToList().OrderByDescending(n => n.HireBookDetail_ID);
            ViewBag.lstHireBookDetail = lst;
            ViewBag.Count = lst.Count();
            return View();
        }

        [HttpPost]
        public ActionResult CancelHireBook(FormCollection name)
        {
            var n = name["name"].ToString();
            IEnumerable<HireBookDetail> lst = db.HireBookDetails.Where(s => s.HireBook.Customer.Name.Contains(n)).ToList().OrderByDescending(s => s.HireBookDetail_ID);
            ViewBag.lstHireBookDetail = lst;
            return View();
        }

        //Lọc theo tên sách
        public ActionResult FillBookName()
        {
            IEnumerable<HireBookDetail> lst = db.HireBookDetails.ToList().OrderByDescending(n => n.HireBookDetail_ID);
            ViewBag.lstHireBookDetail = lst;
            ViewBag.Count = lst.Count();
            return View();
        }

        [HttpPost]
        public ActionResult FillBookName(FormCollection name)
        {
            var n = name["name"].ToString();
            IEnumerable<HireBookDetail> lst = db.HireBookDetails.Where(s => s.Book.Book_Name.Contains(n)).ToList().OrderByDescending(s => s.HireBookDetail_ID);
            ViewBag.lstHireBookDetail = lst;
            ViewBag.Count = lst.Count();
            return View();
        }

        //Lọc theo tên sách
        public ActionResult FillState()
        {
            IEnumerable<HireBookDetail> lst = db.HireBookDetails.ToList().OrderByDescending(n => n.HireBookDetail_ID);
            ViewBag.lstHireBookDetail = lst;
            ViewBag.Count = lst.Count();
            return View();
        }

        [HttpPost]
        public ActionResult FillState(FormCollection state)
        {
            var s = int.Parse(state["state"]);
            IEnumerable<HireBookDetail> lst;
            if (s == 1)
            {
                lst = db.HireBookDetails.Where(n => n.Date_Start == null).ToList().OrderByDescending(n => n.HireBookDetail_ID);

            }
            else if (s == 2)
            {
                IEnumerable<HireBookDetail> temp = db.HireBookDetails.ToList().OrderByDescending(n => n.HireBookDetail_ID);
                List<HireBookDetail> temp1 = new List<HireBookDetail>();
                foreach (var a in temp)
                {
                    if (a.Date_Start != null)
                    {
                        //Kiểm tra cuốn sách có gói ngày là bao nhiêu
                        var day_package = db.Packages.Where(n => n.ID_Package == a.Day_Limit).FirstOrDefault().Day_Limit;
                        TimeSpan checkTime = (TimeSpan)(a.Date_End - DateTime.Now);
                        //LinkedList<HireBookDetail> temp1 = new LinkedList<HireBookDetail>();

                        if ((checkTime.Days > 0 || checkTime.Hours > 0 || checkTime.Minutes > 0 || checkTime.Seconds > 0) && a.Confirm == null)
                            temp1.Add(a);
                    }


                }
                lst = temp1;
            }
            else if (s == 3)
            {

                //lst = db.HireBookDetails.Where(n => DateTime.Now.AddDays(n.Package.Day_Limit) > n.Date_End).ToList().OrderByDescending(n => n.HireBookDetail_ID);
                IEnumerable<HireBookDetail> temp = db.HireBookDetails.ToList().OrderByDescending(n => n.HireBookDetail_ID);
                List<HireBookDetail> temp1 = new List<HireBookDetail>();
                foreach (var a in temp)
                {
                    if (a.Date_Start != null)
                    {
                        //Kiểm tra cuốn sách có gói ngày là bao nhiêu
                        var day_package = db.Packages.Where(n => n.ID_Package == a.Day_Limit).FirstOrDefault().Day_Limit;
                        //var checkTime = DateTime.Now.AddDays(day_package);
                        //LinkedList<HireBookDetail> temp1 = new LinkedList<HireBookDetail>();
                        TimeSpan checkTime = (TimeSpan)(a.Date_End - DateTime.Now);
                        if (checkTime.Days <= 0 && a.Confirm != null)
                            temp1.Add(a);

                    }

                }
                lst = temp1;
            }
            else if (s == 4)
            {
                lst = db.HireBookDetails.Where(n => n.Confirm == 1).ToList().OrderByDescending(n => n.HireBookDetail_ID);

            }
            else
            {
                lst = db.HireBookDetails.ToList().OrderByDescending(n => n.HireBookDetail_ID);
            }
            ViewBag.lstHireBookDetail = lst;
            ViewBag.Count = lst.Count();
            return View();
        }


        //Đóng sách
        public ActionResult CloseBook(int i)
        {
            HireBookDetail hireBookDetail = db.HireBookDetails.Where(s => s.HireBookDetail_ID == i).FirstOrDefault();
            hireBookDetail.Confirm = 1;
            db.SaveChanges();
            return RedirectToAction("CancelHireBook", "Admin/AdminHome");

        }

        public ActionResult ConfirmDeatilHireBook(int i)
        {
            IEnumerable<HireBookDetail> lst = db.HireBookDetails.Where(s => s.ID_HireBook == i).ToList();
            var hirebook_Confirm = db.HireBooks.Where(s => s.ID_HireBook == i).FirstOrDefault().Confirm;
            var hirebook_ID = db.HireBooks.Where(s => s.ID_HireBook == i).FirstOrDefault().ID_HireBook;
            ViewBag.lstConfirmDetailHireBook = lst;
            ViewBag.hirebook_Confirm = hirebook_Confirm;
            ViewBag.HireBook_ID = hirebook_ID;
            return View();
        }
    }
}