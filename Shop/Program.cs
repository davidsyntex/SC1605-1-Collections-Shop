using System;

namespace Shop
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var testCart = new ShoppingCart<string>();

            testCart.Add("Hej");
            testCart.Add("Naab");
            testCart.Add("Jag");
            testCart.Add("Gör");

            testCart.Remove(2);
            testCart.Remove("Hej");
            testCart.Remove(6);
            testCart.Add("En");

            foreach (var cartItem in testCart)
            {
                Console.WriteLine(cartItem);
            }


            Console.ReadLine();
        }
    }
}
