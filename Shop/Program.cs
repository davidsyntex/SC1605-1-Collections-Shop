using System;

namespace Shop
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var testCart = new ShoppingCart<Item>();

            var item = new Item("Skärm", 2000, "LED-skärm från BenQ");
            testCart.Add(item);

            item = new Item("Skärm", 2000, "LED-skärm från BenQ");
            testCart.Add(item);

            testCart.Remove(0);

            foreach (var cartItem in testCart)
            {
                Console.WriteLine(cartItem.Name);
                Console.WriteLine(cartItem.Description);
                Console.WriteLine(cartItem.Price);
                Console.WriteLine("---");
            }

            Console.ReadLine();
        }
    }
}