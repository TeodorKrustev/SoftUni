namespace PowerOfNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            int result = 1;
            for (int time = 1; time <= power; time++)
            {
                result = result * num;
            }
            Console.WriteLine(result);
        }
    }
}
