Dictionary<char, int> characters = new();

string input = Console.ReadLine();

foreach (char ch in input)
{
    if (ch == ' ')
    {
        continue;
    }
    if (characters.ContainsKey(ch))
    {
        characters[ch]++;
    }
    else
    {
        characters.Add(ch, 1);
    }
}

foreach (KeyValuePair<char, int> pair in characters)
{
    Console.WriteLine($"{pair.Key} -> {pair.Value}");
}
