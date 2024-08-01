namespace CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            string extra = Console.ReadLine();
            double price = 0;

            if (order == "coffee")
            {
                price = 1.00;
            }
            else if (order == "tea")
            {
                price = 0.60;
            }
            if (extra == "sugar")
            {
                price = price + 0.40;
            }
            else if (extra == "no")
            {
                price = price + 0.00;
            }
            Console.WriteLine($"Final price: ${price:f2}");
        }
    }
}
