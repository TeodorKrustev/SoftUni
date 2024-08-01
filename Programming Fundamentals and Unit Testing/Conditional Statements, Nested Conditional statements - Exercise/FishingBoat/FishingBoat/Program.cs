namespace FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermanCount = int.Parse(Console.ReadLine());

            double price = 0.0;

            switch (season)
            {
                case "Spring": price = 3000; break;
                case "Summer":
                case "Autumn": price = 4200; break;
                case "Winter": price = 2600; break;

            }
            if (fishermanCount <= 6)

                price = price * 0.9;
            else if (fishermanCount >= 7 && fishermanCount <= 11)
                price = price * 0.85;
            else if (fishermanCount >= 12)
                price = price * 0.75;

            if (fishermanCount % 2 == 0 && season != "Autumn")
            {
                price = price * 0.95;
            }

            if (price <= budget)

                Console.WriteLine($"Yes! You have {(budget - price):F2} leva left.");

            else
                Console.WriteLine($"Not enough money! You need {(price - budget):F2} leva.");

        }
    }
}
