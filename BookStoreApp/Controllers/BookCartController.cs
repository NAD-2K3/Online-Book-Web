using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class BookCartController : Controller
    {
        BookStoreOnlineEntities db = new BookStoreOnlineEntities();

        public ActionResult ThankYouPage()
        {
            return View();
        }

        public List<Cart> GetCart()
        {
            List<Cart> myCart = Session["MyCart"] as List<Cart>;


            if (myCart == null)
            {
                myCart = new List<Cart>();
                Session["MyCart"] = myCart;
            }
            return myCart;
        }

        public ActionResult AddToCart(FormCollection prod)
        {
            //Lấy giỏ hàng hiện tại
            List<Cart> myCart = GetCart();

            int id = int.Parse(prod["IDBook"]);
            int dayPackage = int.Parse(prod["DayPackage"]);

            Cart currentProduct = myCart.FirstOrDefault(p => p.Id == id);
            if (currentProduct == null)
            {
                currentProduct = new Cart(id);
                currentProduct.DayPackage = dayPackage;
                myCart.Add(currentProduct);
            }

            return RedirectToAction("Index", "BookCart");
        }

        // GET: BookCart
        public ActionResult Index()
        {
            List<Cart> myCart = GetCart();
            //Nếu giỏ hàng trống thì trả về trang ban đầu
            if (myCart == null || myCart.Count == 0)
            {
                return RedirectToAction("EmpryCart", "Cart");
            }

            ViewBag.lstDayPackage = db.Packages.ToList();

            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return View(myCart); //Trả về View hiển thị thông tin giỏ hàng
            
        }

        //public ActionResult GetCartInfo()
        //{
        //    List<Cart> myCart = GetCart();
        //    //Nếu giỏ hàng trống thì trả về trang ban đầu
        //    if (myCart == null || myCart.Count == 0)
        //    {
        //        return RedirectToAction("EmpryCart", "Cart");
        //    }
        //    ViewBag.TotalNumber = GetTotalNumber();
        //    ViewBag.TotalPrice = GetTotalPrice();
        //    return View(myCart); //
        //}

        public ActionResult CartPartial()
        {
            ViewBag.TotalNumber = GetTotalNumber();

            return PartialView();
        }

        //public ActionResult EmpryCart()
        //{
        //    ViewBag.EmptyNotification = "Chưa có sản phẩm nào trong giỏ hàng";
        //    return View();
        //}


        public ActionResult RemoveProduct(int id)
        {
            List<Cart> myCart = GetCart();
            Cart currentProduct = myCart.FirstOrDefault(p => p.Id == id);
            myCart.Remove(currentProduct);
            return RedirectToAction("GetCartInfo", "Cart");
        }

        private int GetTotalNumber()
        {
            int totalNumber = 0;
            List<Cart> myCart = GetCart();
            if (myCart != null)
                totalNumber = myCart.Count;
            return totalNumber;
        }

        private decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            List<Cart> myCart = GetCart();
            if (myCart != null)
                totalPrice = myCart.Sum(sp => sp.TotalPrice());
            return totalPrice;
        }


    }
}