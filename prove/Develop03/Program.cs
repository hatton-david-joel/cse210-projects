using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ShowVerse();
    }

    static void ShowVerse(KeyValuePair<string, string> verse = new KeyValuePair<string, string>())
    {
        if (verse.Key == null)
        {
            var scripture = new Scripture();
            scripture.Load();
            verse = scripture.GetRandomVerse();
        }

        var consoleManager = new ConsoleManager();
        var proceed = consoleManager.Display(verse.Key + " " + verse.Value);
        if (!proceed || verse.Value.Split(" ").All(word => word.StartsWith("_")))
        {
            Environment.Exit(0);
        }

        var wordHider = new WordHider();
        var updatedVerse = wordHider.HideWords(verse.Value);
        ShowVerse(new KeyValuePair<string, string>(verse.Key, updatedVerse));
    }
}