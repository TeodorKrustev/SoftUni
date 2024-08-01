namespace Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            double result = 0;

            if (operation == "+")
            {
                result = N1 + N2;
                Console.WriteLine($"{N1} + {N2} = {result} - {(result % 2 == 0 ? "even" : "odd")}");
            }
            else if (operation == "-")
            {
                result = N1 - N2;
                Console.WriteLine($"{N1} - {N2} = {result} - {(result % 2 == 0 ? "even" : "odd")}");
            }
            else if (operation == "*")
            {
                result = N1 * N2;
                Console.WriteLine($"{N1} * {N2} = {result} - {(result % 2 == 0 ? "even" : "odd")}");
            }
            else if (operation == "/" && N2 != 0)
            {
                double devResult = (double)N1 / N2;
                Console.WriteLine($"{N1} / {N2} = {devResult:f2}");
            }
            else if (operation == "%" && N2 != 0)
            {
                int remainder = N1 % N2;
                Console.WriteLine($"{N1} % {N2} = {remainder}");
            }
            else if (N2 == 0)
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
            else
            {
                Console.WriteLine("Invalid operator");
            }
        }
    }
}
