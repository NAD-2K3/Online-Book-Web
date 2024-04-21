using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Patterns.FactoryMethod
{
    internal class FactoryCategory
    {
        public ICategory CreateCategory(string type)
        {
            ICategory category = null;
            switch (type)
            {
                case "Sách Marketing":
                    category = new MarketingBook();
                    break;
                case "Sách tài chính":
                    category = new FinanceBook();
                    break;
                default:
                    throw new Exception();
            }

            return category;
        }
    }
}
