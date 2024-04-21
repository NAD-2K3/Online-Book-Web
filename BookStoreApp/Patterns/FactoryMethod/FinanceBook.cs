﻿using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStoreApp.Patterns.FactoryMethod
{
    internal class FinanceBook : ICategory
    {
        BookStoreOnlineEntities1 db = SingletonPattern.Instance;
        public List<Book> listBookByCategory(int id)
        {
            var categoryName = db.BookCategories.FirstOrDefault(c => c.ID_BookCategory == id);
            var LstProduct = db.Books.Where(b => b.ID_BookCategory == id).ToList();
            return LstProduct;
        }
    }
}
