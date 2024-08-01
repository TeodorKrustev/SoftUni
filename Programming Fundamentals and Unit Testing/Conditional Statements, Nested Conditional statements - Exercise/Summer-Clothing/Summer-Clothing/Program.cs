namespace Summer_Clothing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tempetarure = double.Parse(Console.ReadLine());
            string timeofday = Console.ReadLine();
            string clothing = "";
            string shoes = "";

            if (10 <= tempetarure && tempetarure <= 18)
            {
                if (timeofday == "Morning")
                {
                    clothing = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (timeofday == "Afternoon")
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
                else if (timeofday == "Evening")
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (18 <= tempetarure && tempetarure <= 24)
            {
                if (timeofday == "Morning")
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
                else if (timeofday == "Afternoon")
                {
                    clothing = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (timeofday == "Evening")
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (tempetarure >= 24)
            {
                if (timeofday == "Morning")
                {
                    clothing = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (timeofday == "Afternoon")
                {
                    clothing = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (timeofday == "Evening")
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {tempetarure} degrees, get your {clothing} and {shoes}.");
        }
    }
}
