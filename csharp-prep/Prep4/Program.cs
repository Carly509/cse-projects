using System;

class Program
{
    static void Main(string[] args)
    {
         List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                break;
            }
            numbers.Add(input);
        }

        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }


        double average = (double)sum / numbers.Count;


        int max = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }


        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");


        int smallestPositive = int.MaxValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > 0 && numbers[i] < smallestPositive)
            {
                smallestPositive = numbers[i];
            }
        }

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
