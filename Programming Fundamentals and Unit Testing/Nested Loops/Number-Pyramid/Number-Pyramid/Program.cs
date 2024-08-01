namespace Number_Pyramid
{
    internal class Program
    {
        static void Main_compact()
        {
            int n = int.Parse(Console.ReadLine() ?? "0");

            int row = 1;
            for (int cur = 1; cur <= n;)
            {
                for (int print = 0; print < row && cur <= n; print++)
                    Console.Write($"{cur++} ");

                Console.WriteLine();
                row++;
            }
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine() ?? "0");

            int row = 1;
            int curRow = 0;
            for (int cur = 1; cur <= n; cur++)
            {
                Console.Write(cur + " ");

                curRow++;

                if (curRow >= row)
                {
                    Console.WriteLine();
                    row++;
                    curRow = 0;
                }
            }
        }

        static void Main_lesson()
        {
            int n = int.Parse(Console.ReadLine() ?? "0");

            int current = 1;
            bool isBigger = false;


            for (int rows = 1; rows <= n; rows++)
            {


                for (int cols = 1; cols <= rows; cols++)
                {

                    if (current > n)
                    {

                        isBigger = true;
                        break;
                    }
                    Console.Write(current + " ");
                    current++;
                }


                if (isBigger)
                    break;

                Console.WriteLine();
            }
        }

        static void Main_()
        {
            int n = int.Parse(Console.ReadLine() ?? "0");

            int current = 1;
            bool isBigger = false;
            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (current > n)
                    {
                        isBigger = true;
                        break;
                    }

                    Console.Write(current + " ");
                    current++;
                }

                Console.WriteLine();
                if (isBigger)
                    break;
            }
        }
    }
}
