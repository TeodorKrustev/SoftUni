namespace VacationExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string accommodationType = Console.ReadLine();
            int countOfDays = int.Parse(Console.ReadLine());

            double finalPrice = 0;

            if (season == "Spring")
            {
                if (accommodationType == "Hotel")
                {
                    finalPrice = countOfDays * 30;
                }
                else if (accommodationType == "Camping")
                {
                    finalPrice = countOfDays * 10;
                }
                finalPrice *= (1 - 0.30);
            }
            else if (season == "Summer")
            {
                if (accommodationType == "Hotel")
                {
                    finalPrice = countOfDays * 50;
                }
                else if (accommodationType == "Camping")
                {
                    finalPrice = countOfDays * 30;
                }
            }
            else if (season == "Autumn")
            {
                if (accommodationType == "Hotel")
                {
                    finalPrice = countOfDays * 20;
                }
                else if (accommodationType == "Camping")
                {
                    finalPrice = countOfDays * 15;
                }
                finalPrice *= (1 - 0.30);
            }
            else if (season == "Winter")
            {
                if (accommodationType == "Hotel")
                {
                    finalPrice = countOfDays * 40;
                }
                else if (accommodationType == "Camping")
                {
                    finalPrice = countOfDays * 10;
                }
                finalPrice *= (1 - 0.10);
            }

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
