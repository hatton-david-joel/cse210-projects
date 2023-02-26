using System;

public class BreathingActivity : Activity
{
    private string _message1 = "Breathe in...";
    private string _message2 = "Now breathe out...";
    private string _description = "This activity will help you clear your mind and focus through breathing.";

    public BreathingActivity(string activityName, int activityTime) : base(activityName, activityTime)
    {

    }
    public void GetActivityDescription()
    {
        Console.WriteLine(_description);
    }

    public void Breathing(int seconds)
    {
        Console.WriteLine();
        int secondsTimer = 0;
        while (secondsTimer < seconds)
        {
            Console.WriteLine();
            for (int i = 4; i > 0; i--)
            {
                Console.Write($"{_message1}{i}");
                Thread.Sleep(1000);
                string blank = new string('\b', (_message1.Length + 2));
                Console.Write(blank);
                secondsTimer += 1;
            }
            Console.WriteLine($"{_message1}  ");
            for (int i = 5; i > 0; i--)
            {
                Console.Write($"{_message2}{i}");
                Thread.Sleep(1000);
                string blank = new string('\b', (_message2.Length + 2));
                Console.Write(blank);
                secondsTimer += 1;
            }
            Console.WriteLine($"{_message2}  ");
        }
    }
}
