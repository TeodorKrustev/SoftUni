namespace FoodOrDrink
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            if (product == "curry" || product == "noodles" || product == "sushi" || product == "bread" || product == "spaghetti")
            {
                Console.WriteLine("food");
            }
            else if (product == "tea" || product == "water" || product == "coffee" || product == "juice")
            {
                Console.WriteLine("drink");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
