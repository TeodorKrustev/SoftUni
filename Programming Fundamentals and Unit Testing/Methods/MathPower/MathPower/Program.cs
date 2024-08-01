int MathPower(int baseNum, int power)
{
    int output = baseNum;
    for (int i = 0; i < power - 1; i++)
    {
        output *= baseNum;
    }
    return output;
}

int baseNum = int.Parse(Console.ReadLine());
int power = int.Parse(Console.ReadLine());

int result = MathPower(baseNum, power);


Console.WriteLine(result);
