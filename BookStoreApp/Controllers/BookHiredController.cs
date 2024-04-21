  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class BookHiredController : Controller
    {
        BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1();
        // GET: BookHired
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowBookHired(string i)
        {
            //KHách hàng có thể có nhiều hóa đơn đã thanh toán nên phải load nhiều sách từ nhiều hóa đơn
            //Lẫy ID đơn đặt hàng
            List<HireBook> hireBook = db.HireBooks.Where(s => s.User_Name == i).ToList();
            //Lưu tất cả sách đã đặt của khách
            List<HireBookDetail> hireBookDetails = new List<HireBookDetail>();
            foreach (var item in hireBook)
            {
                if (item.Confirm == 1)
                {
                    //Lấy ra sách theo từng hóa đơn
                    List<HireBookDetail> temp = db.HireBookDetails.Where(s => s.ID_HireBook == item.ID_HireBook).ToList();
                    foreach (var t in temp)
                    {
                        TimeSpan dayleft = (TimeSpan)(t.Date_End - DateTime.Now);
                        int day = dayleft.Days;
                        int hour = dayleft.Hours;
                        int minute = dayleft.Minutes;
                        int second = dayleft.Seconds;
                        //Nếu <= 0 thì sách đã hết hạn, trực tiếp đóng lại
                        if (day <= 0 && hour <= 0 && minute <= 0 && second <= 0)
                        {
                            //Confrim bằng 1 để đóng sách lại
                            t.Confirm = 1;
                        }
                        else
                        {
                            hireBookDetails.Add(t);
                        }
                    }
                }

            }
            ViewBag.lstHireBookDetail = hireBookDetails;
            ViewBag.Count = hireBookDetails.Count();
            db.SaveChanges();
            return View();
        }

        public ActionResult ShowPDFFile(string i)
        {
            ViewBag.pdfFile = i;
            return View();
        }
    }
}