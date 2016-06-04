using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        private static void Main(string[] args)
        {
            ShoppingCart<int> testCart = new ShoppingCart<int>();

            testCart.Add(1);
            testCart.Add(2);
            testCart.Add(3);
            testCart.Add(4);
            Console.ReadLine();
        }
    }
}
