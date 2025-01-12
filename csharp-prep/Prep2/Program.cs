using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int percentage = int.Parse(gradePercentage);
        string grade;
        string gradeMark = "";
        int gradeMarkIdentitfier = percentage % 10;
        string message;

        if (percentage >= 90)
        {
            grade = "A";
        }
        else if (percentage >= 80)
        {
            grade = "B";
        }
        else if (percentage >= 70)
        {
            grade = "C";
        }
        else if (percentage >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        if (gradeMarkIdentitfier >= 7 && grade != "A" && grade != "F")
        {
            gradeMark = "+";
        }
        else if (gradeMarkIdentitfier < 3 && grade != "F")
        {
            gradeMark = "-";
        }

        if (percentage < 70)
        {
            message = " Try getting help from the tutoring center. Better luck next time!";
        }
        else
        {
            message = "";
        }

        Console.WriteLine($"Your grade is: {grade}{gradeMark}.{message}");
    }
}