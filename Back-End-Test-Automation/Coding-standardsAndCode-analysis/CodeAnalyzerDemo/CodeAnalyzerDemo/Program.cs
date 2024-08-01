﻿// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// This is the main class of the program.
/// </summary>
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hi!");
    }

    private static string MakeGreeting(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        return "Hello, " + name;
    }
}
