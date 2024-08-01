namespace NumberOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            string mo = Console.ReadLine();

            double result = 0;

            if (mo == "+")
            {
                result = num1 + num2;
            }
            else if (mo == "-")
            {
                result = num1 - num2;
            }
            else if (mo == "*")
            {
                result = num1 * num2;
            }
            else
            {
                result = num1 / num2;
            }
            Console.WriteLine($"{num1} {mo} {num2} = {result:f2}");

        }
    }
}
