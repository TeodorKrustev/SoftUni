namespace Sum_of_Prime_and_Non_Prime_Numbers
{
    internal class Program
    {
        static void Main()
        {
            int sumOfPrimes = 0;
            int sumOfNonPrimes = 0;

            while (true)
            {
                String input = Console.ReadLine();

                if (input == "stop")
                    break;

                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                int divisors = 0;
                for (int i = 1; i <= number; i++)
                    if (number % i == 0)
                        divisors++;

                if (divisors == 2)

                    sumOfPrimes += number;
                else

                    sumOfNonPrimes += number;
            }

            Console.WriteLine("Sum of all prime numbers is: " + sumOfPrimes);
            Console.WriteLine("Sum of all non prime numbers is: " + sumOfNonPrimes);

        }
    }
}
