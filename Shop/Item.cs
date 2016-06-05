namespace Shop
{
    public class Item
    {
        public string Name { get; }
        public double Price { get; }
        public string Description { get; }

        public Item(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}