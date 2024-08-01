namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string screening = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            double totalPrice = 0;

            switch (screening)
            {
                case "Premiere":
                    totalPrice = rows * cols * 12.00;
                    break;
                case "Normal":
                    totalPrice = rows * cols * 7.50;
                    break;
                case "Discount":
                    totalPrice = rows * cols * 5.00;
                    break;
            }

            Console.WriteLine("{0:f2} leva", totalPrice);
        }
    }
}