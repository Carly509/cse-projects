using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    public ListingActivity() : base("Welcome to the Listing Activity!", "Great job on completing the Listing Activity!")
    {
    }

    public override void Run()
    {
        StartActivity();
        Console.WriteLine("This activity will help you think of things you are grateful for.");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item you are grateful for (or type 'done' to finish): ");
            string item = Console.ReadLine();
            if (item.ToLower() == "done") break;
            items.Add(item);
        }

        Console.WriteLine("Here are your items:");
        foreach (var i in items)
        {
            Console.WriteLine($"- {i}");
        }

        EndActivity();
    }
}
