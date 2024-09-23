using System;

class Program
{
    static void Main(string[] args)
    {
       Random random = new Random();
        bool playAgain;

        do
        {
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Welcome to Guess My Number!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"You took {guessCount} guesses.");

            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";

        } while (playAgain);

        Console.WriteLine("Thanks for playing!");

    }
}
