using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApp.Controllers
{
    public class DetailBookController : Controller
    {
        // GET: DetailBook
        public ActionResult Index()
        {
            return View();
        }
    }
}