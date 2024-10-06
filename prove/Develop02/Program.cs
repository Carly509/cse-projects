using System;
using System.IO;

public class JournalEntry
{
    public string Date;
    public string Prompt;
    public string Response;
    public string Mood;

    public JournalEntry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }
}

public class Journal
{
    public JournalEntry[] entries;
    public int entryCount;
    public string[] prompts;
    public string[] moods;

    public Journal()
    {
        entries = new JournalEntry[100];  // Assume max 100 entries
        entryCount = 0;
        prompts = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        moods = new string[] { "Happy", "Sad", "Excited", "Anxious", "Calm" };
    }

    public void AddEntry(string prompt, string response, string mood)
    {
        if (entryCount < entries.Length)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            entries[entryCount] = new JournalEntry(date, prompt, response, mood);
            entryCount++;
        }
        else
        {
            Console.WriteLine("Journal is full. Cannot add more entries.");
        }
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\nJournal Entries:");
        for (int i = 0; i < entryCount; i++)
        {
            Console.WriteLine($"{entries[i].Date} - Prompt: {entries[i].Prompt}");
            Console.WriteLine($"Response: {entries[i].Response}");
            Console.WriteLine($"Mood: {entries[i].Mood}\n");
        }
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }

    public void DisplayMoodOptions()
    {
        Console.WriteLine("How are you feeling today?");
        for (int i = 0; i < moods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {moods[i]}");
        }
    }

    public string GetMoodChoice()
    {
        while (true)
        {
            Console.Write("Enter the number of your mood: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= moods.Length)
            {
                return moods[choice - 1];
            }
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            for (int i = 0; i < entryCount; i++)
            {
                writer.WriteLine($"{entries[i].Date}|{entries[i].Prompt}|{entries[i].Response}|{entries[i].Mood}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entryCount = 0;
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    entries[entryCount] = new JournalEntry(parts[0], parts[1], parts[2], parts[3]);
                    entryCount++;
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved journal found. Starting with an empty journal.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        journal.LoadFromFile("journal.txt");
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = journal.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Enter your journal response: ");
                    string response = Console.ReadLine();
                    journal.DisplayMoodOptions();
                    string mood = journal.GetMoodChoice();
                    journal.AddEntry(prompt, response, mood);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    journal.SaveToFile("journal.txt");
                    break;

                case "4":
                    journal.SaveToFile("journal.txt");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
