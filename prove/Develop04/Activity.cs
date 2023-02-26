using System;

public class Activity
{
    private string _activityName;
    private int _activityTime;
    private string _message = "You may begin in...";

    public Activity(string activityName, int activityTime)
    {
        _activityName = activityName;
        _activityTime = activityTime;
    }
    public void GetActivityName()
    {
        Console.WriteLine($"Welcome to the {_activityName} Activity\n");
    }
    public void SetActivityName(string activityName)
    {
        _activityName = activityName;
    }
    public int GetActivityTime()
    {
        Console.Write("\nHow many seconds would you like this session to be? ");
        int userSeconds = Int32.Parse(Console.ReadLine());
        _activityTime = userSeconds;
        return userSeconds;
    }
    public void SetActivityTime(int activityTime)
    {
        _activityTime = activityTime;
    }

    public void GetReady()
    {
        Console.Clear();
        Spinner spinner = new Spinner();
        spinner.ShowSpinner(SpinnerType.Start);
    }

    public void GetDone()
    {
        Spinner spinner = new Spinner();
        spinner.ShowSpinner(SpinnerType.End);
        Console.WriteLine($"\nYou have completed another {_activityTime} seconds of the {_activityName} Activity!");
        spinner.ShowSpinner(SpinnerType.Basic);
    }
     public void CountDown()
    {
        Console.WriteLine(); 
        for (int i = 5; i > 0; i--)
        {
            Console.Write($"{_message}{i}");
            Thread.Sleep(1000);
            string blank = new string('\b', (_message.Length + 2)); 
            Console.Write(blank);
        }
        Console.WriteLine($"Go:                               "); 
    }


}