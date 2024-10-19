using System;
using System.Threading;

public abstract class Activity
{
    protected int duration;

    public Activity(string startMessage, string endMessage)
    {
        Console.WriteLine(startMessage);
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine(endMessage);
    }

    public abstract void Run();
    protected void StartActivity()
    {
        Console.WriteLine("Activity is starting...");
    }

    protected void EndActivity()
    {
        Console.WriteLine("Activity has ended. Great job!");
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
