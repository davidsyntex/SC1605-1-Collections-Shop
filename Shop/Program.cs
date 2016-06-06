using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Shop
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var testCart = new ShoppingCart<Item>();

            testCart.Add(new Item("Skärm", 2000, "LED-skärm från BenQ"));
            testCart.Add(new Item("Skärm", 2000, "LED-skärm från BenQ"));
            testCart.Add(new Item("Skärm", 2000, "LED-skärm från BenQ"));
            testCart.Add(new Item("Skärm", 4000, "Dyr skärm från BenQ"));
            var item = new Item("Skärm", 2000, "LED-skärm från BenQ");
            testCart.Add(item);

            testCart.Remove(0);
            testCart.Remove(item);

            testCart.SortPriceAscending();
            Console.WriteLine("Ascending");

            foreach (var cartItem in testCart)
            {
                if (cartItem == null) continue;
                Console.WriteLine(cartItem.Name);
                Console.WriteLine(cartItem.Description);
                Console.WriteLine(cartItem.Price);
                Console.WriteLine("---");
            }

            Console.WriteLine($"Dyrast: {testCart.CalculatePrice()}");
            Console.WriteLine(testCart.GetMostExpensiveItem().Name);
            Console.WriteLine(testCart.GetMostExpensiveItem().Price);
            Console.WriteLine(testCart.GetMostExpensiveItem().Description);

            testCart.SortPriceDescending();
            Console.WriteLine("Descending");

            foreach (var cartItem in testCart)
            {
                if (cartItem == null) continue;
                Console.WriteLine(cartItem.Name);
                Console.WriteLine(cartItem.Description);
                Console.WriteLine(cartItem.Price);
                Console.WriteLine("---");
            }

            Console.ReadLine();
        }
    }
}