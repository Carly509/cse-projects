using System;
using System.Collections.Generic;
using System.IO;

class Scripture
{
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference + ":");
        foreach (Word word in words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public bool HideRandomWords(int count)
    {
        int hiddenCount = 0;
        Random random = new Random();
        while (hiddenCount < count)
        {
            int index = random.Next(words.Count);
            Word word = words[index];
            if (!word.IsHidden)
            {
                word.Hide();
                hiddenCount++;
            }
        }


        foreach (Word word in words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}

class Word
{
    private string text;
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        this.text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string GetDisplayText()
    {
        return IsHidden ? new string('_', text.Length) : text;
    }
}

class Program
{
    static void Main(string[] args)
    {

        string[] lines = File.ReadAllLines("scriptures.txt");
        if (lines.Length > 0)
        {

            string[] parts = lines[0].Split('|');
            if (parts.Length == 2)
            {
                Scripture scripture = new Scripture(parts[0], parts[1]);

                bool allHidden = false;
                while (!allHidden)
                {
                    scripture.Display();
                    Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
                    string input = Console.ReadLine().ToLower();

                    if (input == "quit")
                        return;

                    allHidden = scripture.HideRandomWords(3);
                }

                Console.WriteLine("All words are hidden. Press Enter to exit.");
                Console.ReadLine();
            }
        }
    }
}

//Additional features for creativity:

//A ScriptureLibrary class that loads multiple scriptures from a file.
//Random selection of scriptures from the library for memorization.
//Continuous learning experience by allowing users to start with a new scripture after completing one.
//Improved readability by displaying underscores matching the word length for hidden words.

//To use this program:

//Create a file named "scriptures.txt" in the same directory as the executable.
//Add scriptures to the file in the format: "Reference|Book Chapter:Verse(-EndVerse)|Scripture Text"
//Run the program, and it will randomly select scriptures from the file for memorization.
