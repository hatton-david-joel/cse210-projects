using System;
using System.Diagnostics;

public class Spinner
{
    int counter;
    private void ConsoleSpinner()
    {
        counter = 0;
    }

    public void ShowSpinner(SpinnerType type)
    {
        var text = string.Empty;
        switch(type)
        {
            case SpinnerType.Basic:
                text = string.Empty;
                break;
            case SpinnerType.Start:
                text = "Get ready... ";
                break;  
            case SpinnerType.End:
                text = "Well done! ";
                break;                
        }

        var counter = 0;
        for (int i = 0; i < 50; i++)
        {
            Console.Clear();
            switch (counter % 4)
            {
                case 0: Console.Write(text + "/"); break;
                case 1: Console.Write(text + "-"); break;
                case 2: Console.Write(text + "\\"); break;
                case 3: Console.Write(text + "|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            counter++;
            Thread.Sleep(75);
        }
    }
}
