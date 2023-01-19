using System;

class Program
{
    static void Main(string[] args)
    { 

        Job job1 = new Job();
        job1._company = "Five Star Parks";
        job1._jobTitle = "Marketing Manager";
        job1._yearStarted = "2022";
        job1._yearEnded = "Current";
    
        Job job2 = new Job();
        job2._company = "Keller Williams Greater Lexington";
        job2._jobTitle = "Technology Specialist";
        job2._yearStarted = "2019";
        job2._yearEnded = "2022";

        Resume myResume = new Resume();
        myResume._name = "David Hatton";
    
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }

}