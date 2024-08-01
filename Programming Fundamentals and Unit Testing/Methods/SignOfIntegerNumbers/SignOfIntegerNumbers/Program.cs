static void PrintNumberSign(int N)
{
    if (N > 0)
    {
        Console.WriteLine($"The number {N} is positive.");
    }
    else if (N < 0)
    {
        Console.WriteLine($"The number {N} is negative.");
    }
    else
    {
        Console.WriteLine($"The number {N} is zero.");
    }
}
int N = int.Parse(Console.ReadLine());
PrintNumberSign(N);
