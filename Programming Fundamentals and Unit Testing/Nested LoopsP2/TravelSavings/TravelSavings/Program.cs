string destination = Console.ReadLine();

while (destination != "End")
{
    double neededSum = double.Parse(Console.ReadLine());
    double collectedSum = 0;
    while (collectedSum < neededSum)
    {
        double sumToBeAdded = double.Parse(Console.ReadLine());
        collectedSum += sumToBeAdded;
        Console.WriteLine($"Collected: {collectedSum:f2}");
    }
    Console.WriteLine($"Going to {destination}!");

    destination = Console.ReadLine();
}
