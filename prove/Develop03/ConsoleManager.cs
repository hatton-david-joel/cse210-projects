using System;

public class ConsoleManager
{
    public bool Display(string text)
    {
        Console.Clear();
        Console.WriteLine(text);
        Console.WriteLine();
        Console.WriteLine("Press enter to continue, or type Quit to exit.");
        var input = Console.ReadLine();
        if (input.ToLower() == "quit")
        {
            return false;
        }

        return true;
    }
}