using BookStoreApp.Controllers;
using BookStoreApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Patterns.Iterator
{
    public class ProductsIterator : IEnumerable
    {
        BookStoreOnlineEntities1 db = new HomeController().db;
        private List<Book> listbook; 
        public ProductsIterator() 
        {
            this.listbook = db.Books.ToList();
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var item in this.listbook) 
            {
                yield return item; 
            }
        }
    }
}
