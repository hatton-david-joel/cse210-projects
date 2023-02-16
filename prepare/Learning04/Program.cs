using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment firstAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(firstAssignment.GetSummary());

        MathAssignment secondAssignment = new MathAssignment("David Hatton", "Division", "7.3", "8-19");
        Console.WriteLine(secondAssignment.GetSummary());
        Console.WriteLine(secondAssignment.GetHomeworkList());

        WritingAssignment thirdAssignment = new WritingAssignment("Neal Walters", "Music", "Reading Music");
        Console.WriteLine(thirdAssignment.GetSummary());
        Console.WriteLine(thirdAssignment.GetWritingInformation());
    }
}