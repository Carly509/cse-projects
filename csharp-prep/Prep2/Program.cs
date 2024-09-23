using System;

class Program
{
    static void Main(string[] args)
    {
          Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }


        if (gradePercentage >= 70)
        {
            Console.WriteLine($"Congratulations! You passed the course with a grade of {letter}.");
        }
        else
        {
            Console.WriteLine($"Unfortunately, you did not pass the course. Your grade is {letter}. Keep trying!");
        }


        string sign = "";
        if (letter == "A")
        {
            sign = ""; // No A+
        }
        else if (letter == "F")
        {
            sign = "";
        }
        else if (letter != "")
        {
            int lastDigit = gradePercentage % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }


        if (letter != "F") // No sign for F
        {
            Console.WriteLine($"Your final grade is {letter}{sign}.");
        }
        else
        {
            Console.WriteLine($"Your final grade is {letter}.");
        }
    }
}
