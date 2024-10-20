using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Welcome to the Reflection Activity!", "Well done on completing the Reflection Activity!")
    {
    }

    public override void Run()
    {
        StartActivity();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");

        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);
        Countdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string question = questions[rand.Next(questions.Length)];
            Console.WriteLine(question);
            Spinner();
        }

        EndActivity();
    }

    private void Spinner()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
