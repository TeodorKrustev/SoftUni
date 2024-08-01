namespace First_N_NumbersSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int index = 1; index <= n; index += 1)
            {
                if (index == 1)
                {
                    Console.Write(index);
                }
                else
                {
                    Console.Write("+" + index);
                }

                sum += index;

            }
            Console.WriteLine("=" + sum);
        }
    }
}
