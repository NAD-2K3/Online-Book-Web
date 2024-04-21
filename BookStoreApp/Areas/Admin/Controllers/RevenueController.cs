using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Areas.Admin.Controllers
{
    public class RevenueController : Controller
    {
        BookStoreOnlineEntities1 db = new BookStoreOnlineEntities1();


        // GET: Admin/Revenue
        [HttpGet]
        public ActionResult Index()
        {
            //ViewBag.DayStart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //ViewBag.DayEnd = DateTime.Now;
            ViewBag.Proceeds = 0;
            ViewBag.Expense = 0;
            ViewBag.Noti = "";
            ViewBag.Revenue = 0;

            ViewBag.ListOrder = new List<HireBook>();
            ViewBag.ListExpenses = new List<Expense>();

            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection inputDate)
        {
            
                DateTime parseDatetime;

                if(DateTime.TryParse(inputDate["dayStart"], out parseDatetime) && DateTime.TryParse(inputDate["dayEnd"], out parseDatetime))
                {
                    var dayStart = DateTime.Parse(inputDate["dayStart"]);
                    var dayEnd = DateTime.Parse(inputDate["dayEnd"]);


                    ViewBag.ListOrder = db.HireBooks.Where(lst => lst.Date_Start >= dayStart && lst.Date_Start <= dayEnd && lst.Confirm == 1).ToList();

                    ViewBag.Proceeds = 0;


                    foreach (var item in ViewBag.ListOrder)
                    {
                        ViewBag.Proceeds += item.Total;
                    }



                    var lstExpense = db.Expenses.Where(lst => lst.Date_Expense >= dayStart && lst.Date_Expense <= dayEnd).ToList();
                    ViewBag.ListExpenses = lstExpense;

                    ViewBag.Expense = 0;
                    foreach (var item in lstExpense)
                    {
                        ViewBag.Expense += item.Price;

                    }

                    ViewBag.Revenue = ViewBag.Proceeds - ViewBag.Expense;
                    return View();
            }
            else
            {
                ViewBag.Noti = "Nhập đủ ngày vô";
                ViewBag.Proceeds = 0;
                ViewBag.Expense = 0;
                //ViewBag.Noti = "";
                ViewBag.Revenue = 0;

                ViewBag.ListOrder = new List<HireBook>();
                ViewBag.ListExpenses = new List<Expense>();
                return View();

            }


        }
    }
}