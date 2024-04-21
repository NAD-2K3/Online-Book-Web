using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApp.Patterns.Command
{
    public class Account
    {
        private readonly BookStoreOnlineEntities1 db = SingletonPattern.Instance;
        private string User_name;
        private string Password;

        public Account(string username, string password)
        {
            this.User_name = username;
            this.Password = password;
        }

        public void Login()
        {
            var checkcus = db.Customers.Where(s => s.User_Name == this.User_name && s.Password == this.Password).FirstOrDefault();
            if (checkcus == null)
            {
                throw new Exception("Đăng nhập không hợp lệ");
            }

            db.Configuration.ValidateOnSaveEnabled = false;
            HttpContext.Current.Session["User_Name"] = checkcus.User_Name;
            HttpContext.Current.Session["Name"] = checkcus.Name;

        }

        public void Logout()
        {
            HttpContext.Current.Session["User_Name"] = null;
            HttpContext.Current.Session["Name"] = null;
            HttpContext.Current.Session["Password"] = null;
        }
    }
}
