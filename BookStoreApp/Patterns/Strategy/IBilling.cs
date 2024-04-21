using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Patterns.Strategy
{
    internal interface IBilling
    {
        decimal Checkout(decimal price); 
    }
}
