using System;
using System.Linq;

public class WordHider
{
    public string HideWords(string text)
    {
        var words = text.Split(" ").ToList();
        var random = new Random();
        var numWordsToHide = random.Next(1, 4);
        for (var i = 0; i < numWordsToHide; i++)
        {
            var randomWordIndex = random.Next(0, words.Count);
            HideWord(words, randomWordIndex);
        }

        return string.Join(" ", words);
    }

    private void HideWord(List<string> words, int indexToHide)
    {
        if (!words[indexToHide].StartsWith("_"))
        {
            words[indexToHide] = new string('_', words[indexToHide].Length);
            return;
        }

        for (var i = indexToHide; i < words.Count; i++)
        {
            if (!words[i].StartsWith("_"))
            {
                words[i] = new string('_', words[i].Length);
                return;
            }
        }

        for (var i = indexToHide; i > 0; i--)
        {
            if (!words[i].StartsWith("_"))
            {
                words[i] = new string('_', words[i].Length);
                return;
            }
        }
    }
}