namespace Freezing_Weather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the temperature: ");
            double temperature = double.Parse(Console.ReadLine());

            if (temperature < 0)
            {
                Console.WriteLine("Freezing weather!");
            }
        }
    }
}
