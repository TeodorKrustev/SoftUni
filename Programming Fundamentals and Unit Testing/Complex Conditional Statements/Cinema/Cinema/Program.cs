namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfMovie = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());

            int totalSeats = rows * seats;

            double totalSum = 0.00;

            if (typeOfMovie == "Premiere")
            {
                totalSum = totalSeats * 12.00;
            }
            else if (typeOfMovie == "Normal")
            {
                totalSum = totalSeats * 7.50;
            }
            else if (typeOfMovie == "Discount")
            {
                totalSum = totalSeats * 5.00;
            }
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
