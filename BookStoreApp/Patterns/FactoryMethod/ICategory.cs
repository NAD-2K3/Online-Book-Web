using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Patterns.FactoryMethod
{
    internal interface ICategory
    {
        List<Book> listBookByCategory(int id);
    }
}
