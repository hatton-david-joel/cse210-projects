using System;
using System.IO;

class Program {
    static List<JournalEntry> _entries = new List<JournalEntry>();

    static string[] _prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static void Main(string[] args) {
        LoadMenu();
    }

    static void LoadMenu() {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");

        var input = Console.ReadLine();
        var inputCheck = int.TryParse(input, out int menuOption);

        if (!inputCheck || menuOption < 1 || menuOption > 5) {
            Console.WriteLine("Please Select a valid menu option.");
            Console.WriteLine();
            LoadMenu();
        }

        switch (menuOption) {
            case 1:
                WriteJournal();
                break;
            case 2:
                DisplayJournal();
                break;
            case 3:
                LoadJournal();
                break;
            case 4:
                SaveJournal();
                break;
            case 5:
                Quit();
                break;
        }
    }

    static void WriteJournal() {
        var random = new Random();
        var prompt = _prompts[random.Next(0, 5)];
        Console.WriteLine(prompt);
        Console.Write("> ");
        var response = Console.ReadLine();
        _entries.Add(new JournalEntry {
            Entry = response,
            Date = DateTime.Now,
            Prompt = prompt
        });

        LoadMenu();
    }
    
    static void DisplayJournal() {
        foreach(var entry in _entries) {
            Console.WriteLine($"Date: {entry.Date.ToString("d")} - Prompt: {entry.Prompt}");
            Console.WriteLine(entry.Entry);
            Console.WriteLine();
        }

        LoadMenu();
    }
    
    static void SaveJournal() {
        Console.WriteLine("What is the filename?");
        Console.Write("> ");
        var response = Console.ReadLine();
        var text = string.Empty;
        foreach(var entry in _entries) {
            text += entry.Date.ToString("d") + ",";
            text += entry.Entry + ",";
            text += entry.Prompt;
            text += "\n";
        }
        File.WriteAllText(response, text);

        LoadMenu();
    }

    static void LoadJournal() {
        Console.WriteLine("What is the filename?");
        Console.Write("> ");
        var response = Console.ReadLine();
        var text = File.ReadAllText(response);
        var lines = text.Split("\n");
        _entries.Clear();
        foreach(var line in lines) {
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            var pieces = line.Split(",");
            _entries.Add(new JournalEntry {
                Date = DateTime.Parse(pieces[0]),
                Entry = pieces[1],
                Prompt = pieces[2]
            });
        }

        LoadMenu();
    }

    static void Quit() {
        Environment.Exit(0);
    }
}