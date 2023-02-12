using System;
using System.IO;
using System.Linq;

public class Scripture
{
    private Dictionary<string, string> verses;

    public void Load()
    {
        verses = new Dictionary<string, string>();
        var text = File.ReadAllText("Scripture.csv");
        var lines = text.Split("\n");
        foreach(var line in lines)
        {
            var columns = line.Split("\t");
            verses.Add(columns[0], columns[1]);
        }
    }

    public KeyValuePair<string, string> GetRandomVerse()
    {
        var random = new Random();
        var randomIndex = random.Next(0, verses.Count);
        var verse = verses.ElementAt(randomIndex);
        return new KeyValuePair<string, string>(verse.Key, verse.Value);
    }
}