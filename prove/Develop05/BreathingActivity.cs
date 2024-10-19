using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Welcome to the Breathing Activity!", "Great job on completing the Breathing Activity!")
    {
    }

    public override void Run()
    {
        StartActivity();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Countdown(4);
            Console.WriteLine("Breathe out...");
            Countdown(4);
        }

        EndActivity();
    }
}
