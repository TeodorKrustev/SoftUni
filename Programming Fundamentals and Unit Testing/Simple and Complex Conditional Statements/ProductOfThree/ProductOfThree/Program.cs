﻿namespace ProductOfThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else if (num1 > 0 && num2 > 0 && num3 > 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 > 0 && num2 > 0 && num3 < 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 > 0 && num2 < 0 && num3 > 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 > 0 && num2 < 0 && num3 < 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 < 0 && num2 > 0 && num3 > 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 < 0 && num2 > 0 && num3 < 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 < 0 && num2 < 0 && num3 > 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 < 0 && num2 < 0 && num3 < 0)
            {
                Console.WriteLine("negative");
            }
        }
    }
}
