int countCharacters = int.Parse(Console.ReadLine());
int sumValues = 0;

for (int i = 1; i <= countCharacters; i++)
{
    char symbol = char.Parse(Console.ReadLine());


    switch (symbol)
    {
        case 'a':
            sumValues += 1;
            break;
        case 'e':
            sumValues += 2;
            break;
        case 'i':
            sumValues += 3;
            break;
        case 'o':
            sumValues += 4;
            break;
        case 'u':
            sumValues += 5;
            break;
    }
}

Console.WriteLine(sumValues);