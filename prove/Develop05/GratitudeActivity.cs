using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base("Welcome to the Gratitude Activity!", "Great job on completing the Gratitude Activity!")
    {
    }

    public override void Run()
    {
        StartActivity();
        Console.WriteLine("This activity will help you reflect on the things you are grateful for.");

        List<string> gratitudeItems = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter something you are grateful for (or type 'done' to finish): ");
            string item = Console.ReadLine();
            if (item.ToLower() == "done") break;
            gratitudeItems.Add(item);
        }

        Console.WriteLine("Here are the things you are grateful for:");
        foreach (var gratitude in gratitudeItems)
        {
            Console.WriteLine($"- {gratitude}");
        }

        EndActivity();
    }
}
