using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreApp.Models; 

namespace BookStoreApp.Models
{
    public class Cart
    {
        BookStoreOnlineEntities db = new BookStoreOnlineEntities();
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Image { get; set; }

        public int DayPackage { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice()
        {
            return Price * DayPackage;
        }

        public Cart(int Id)
        {
            this.Id = Id;
            var productDB = db.Books.Single(s => s.ID_Book == this.Id);
            this.Name = productDB.Book_Name;
            this.Image = productDB.Image;
            this.DayPackage = 0;
            this.Price = productDB.PriceHire;
        }
    }
}