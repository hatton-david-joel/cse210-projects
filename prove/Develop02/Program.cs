using System;
using System.IO;
class Program {
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
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                Quit();
                break;
        }
    }
    
    static void DisplayJournal() {

    }
    
    static void SaveJournal() {

    }

    static void LoadJournal() {

    }

    static void Quit() {
        Environment.Exit(0);
    }
}