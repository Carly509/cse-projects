using System;

namespace EnhancedJournalApp
{
    public class JournalEntry
    {
        public string Date;
        public string Response;
        public string Mood;
        public string Location;

        public JournalEntry(string response, string mood, string location)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Response = response;
            Mood = mood;
            Location = location;
        }
    }

    public class Journal
    {
        public List<JournalEntry> entries = new List<JournalEntry>();


        public void AddEntry(string response, string mood, string location)
        {
            entries.Add(new JournalEntry(response, mood, location));
        }


        public void DisplayEntries()
        {
            Console.WriteLine("\nJournal Entries:");
            foreach (var entry in entries)
            {
                Console.WriteLine($"{entry.Date}: {entry.Response} (Mood: {entry.Mood}, Location: {entry.Location})");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Write a new entry");
                Console.WriteLine("2. Display journal entries");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your journal response: ");
                        string response = Console.ReadLine();

                        Console.Write("Enter your mood: ");
                        string mood = Console.ReadLine();

                        Console.Write("Enter your location: ");
                        string location = Console.ReadLine();

                        journal.AddEntry(response, mood, location);
                        break;

                    case "2":
                        journal.DisplayEntries();
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
