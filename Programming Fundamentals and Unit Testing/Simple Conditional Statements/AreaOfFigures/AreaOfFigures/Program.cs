namespace AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfFigure = Console.ReadLine();


            if (typeOfFigure == "square")
            {
                double size = double.Parse(Console.ReadLine());
                double area = size * size;

                Console.WriteLine($"{area:f2}");
            }
            else if (typeOfFigure == "rectangle")
            {
                double sizeA = double.Parse(Console.ReadLine());
                double sizeB = double.Parse(Console.ReadLine());
                double area = sizeA * sizeB;
                Console.WriteLine($"{area:f2}");
            }
            else if (typeOfFigure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = Math.PI * Math.Pow(radius, 2);
                Console.WriteLine($"{area:f2}");
            }
            else
            {
                Console.WriteLine("Invalid figure.");
            }
        }
    }
}
