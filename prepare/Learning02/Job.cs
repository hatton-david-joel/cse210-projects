using System;

public class Job
{        
    public string _company;
    public string _jobTitle;
    public string _yearStarted;
    public string _yearEnded;

    public void Display()
    {
        Console.WriteLine($"{_company} ({_jobTitle}) {_yearStarted} - {_yearEnded}");
    }
    

}