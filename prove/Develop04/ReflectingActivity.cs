using System;
using System.Diagnostics;

public class ReflectingActivity : Activity
{ 
    private List<string> _promptList = new List<string>
    {
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."
    };
    private List<string> _questionList = new List<string>
    {
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
    };
    
    private const string _description = "This activity will help you reflect on times in your life when you have shown strength.";

    public ReflectingActivity(string activityName, int activityTime) : base(activityName, activityTime)
    {

    }
    public void GetActivityDescription()
    {
        Console.WriteLine(_description);
    }
    private string GetRandomPrompt()
    {
        var random = new Random();
        int index = random.Next(_promptList.Count);
        return _promptList[index];
    }
    private string GetRandomQuestion()
    {
        var random = new Random();
        int index = random.Next(_questionList.Count);
        return _questionList[index];
    }
    public void ShowPrompt(int seconds)
    {
        Console.WriteLine();
        var prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine($"\nWhen you have something in mind, press enter to continue.");

        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Enter)
        {
            ShowQuestion(seconds);
        }
    }
    public void ShowQuestion(int seconds)
    {
        Spinner spinner = new Spinner();
        var question = GetRandomQuestion();
        Console.WriteLine($"\nNow think about each of the following questions as they related to this experience.");
        CountDown();
        Console.Clear();

        Stopwatch timer = new Stopwatch();
        timer.Start();
        Console.Write($"\n>> {question}  ");
        while (timer.Elapsed.TotalSeconds < seconds)
        {
            Thread.Sleep(100);
            //spinner.ShowSpinner(SpinnerType.Basic);//
        }
        Console.Clear();
        timer.Stop();
    }
}