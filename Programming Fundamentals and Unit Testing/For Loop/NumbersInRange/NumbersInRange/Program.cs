namespace NumbersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startOfRange = int.Parse(Console.ReadLine());
            int endOfRange = int.Parse(Console.ReadLine());

            for (int i = startOfRange; i <= endOfRange; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
