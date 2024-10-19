using System;

class Program
{
    static void Main(string[] args)
    {
        Activity activity = null;

        Console.WriteLine("Choose an activity (1: Breathing, 2: Reflection, 3: Listing, 4: Gratitude): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                activity = new BreathingActivity();
                break;
            case "2":
                activity = new ReflectionActivity();
                break;
            case "3":
                activity = new ListingActivity();
                break;
            case "4":
                activity = new GratitudeActivity();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        activity.Run();
    }
}
