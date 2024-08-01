namespace Ski_Holiday
{
    internal class Program
    {
        private const double RoomPrice = 118;
        private const double ApartmentPrice = 155;
        private const double PresidentApartmentPrice = 235;

        static void Main(string[] args)
        {
            int days = GetNumberOfDays();
            string type = GetRoomType();
            string assessment = GetAssessment();

            double nightPrice = CalculateNightPrice(type, days);

            double totalStayPrice = CalculateTotalStayPrice(days, nightPrice, assessment);

            Console.WriteLine("{0:f2}", totalStayPrice);
        }

        private static int GetNumberOfDays()
        {
            Console.Write("Enter the number of days: ");
            if (!int.TryParse(Console.ReadLine(), out int days) || days <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of days.");
                return GetNumberOfDays();
            }
            return days;
        }

        private static string GetRoomType()
        {
            Console.WriteLine("Enter room type (room for one person, apartment, president apartment): ");
            string type = Console.ReadLine().ToLower();
            if (type != "room for one person" && type != "apartment" && type != "president apartment")
            {
                Console.WriteLine("Invalid room type. Please enter one of the provided options.");
                return GetRoomType();
            }
            return type;
        }

        private static string GetAssessment()
        {
            Console.WriteLine("Enter assessment (positive or negative): ");
            string assessment = Console.ReadLine().ToLower();
            if (assessment != "positive" && assessment != "negative")
            {
                Console.WriteLine("Invalid assessment. Please enter positive or negative.");
                return GetAssessment();
            }
            return assessment;
        }

        private static double CalculateNightPrice(string type, int days)
        {
            double nightPrice = 0;
            switch (type)
            {
                case "room for one person":
                    nightPrice = RoomPrice;
                    break;
                case "apartment":
                    nightPrice = ApartmentPrice;
                    if (days < 10)
                        nightPrice *= 0.7;
                    else if (days >= 10 && days <= 15)
                        nightPrice *= 0.65;
                    else if (days > 15)
                        nightPrice *= 0.5;
                    break;
                case "president apartment":
                    nightPrice = PresidentApartmentPrice;
                    if (days < 10)
                        nightPrice *= 0.9;
                    else if (days >= 10 && days <= 15)
                        nightPrice *= 0.85;
                    else if (days > 15)
                        nightPrice *= 0.8;
                    break;
            }
            return nightPrice;
        }

        private static double CalculateTotalStayPrice(int days, double nightPrice, string assessment)
        {
            double totalStayPrice = (days - 1) * nightPrice;
            switch (assessment)
            {
                case "positive":
                    totalStayPrice *= 1.25;
                    break;
                case "negative":
                    totalStayPrice *= 0.9;
                    break;
            }
            return totalStayPrice;
        }
    }
}
