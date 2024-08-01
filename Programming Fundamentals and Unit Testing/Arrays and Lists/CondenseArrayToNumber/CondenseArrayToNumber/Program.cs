List<int> input = Console.ReadLine()
  .Split()
   .Select(int.Parse)
   .ToList();

List<int> output = new List<int>();

while (input.Count > 1)
{
    for (int i = 0; i < input.Count - 1; i++)
    {
        int num1 = input[i];
        int num2 = input[i + 1];
        int sum = num1 + num2;
        output.Add(sum);
    }

    input = output;
    output = new List<int>();
}

Console.WriteLine(input[0]);