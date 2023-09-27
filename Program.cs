//Tom Ellner NET23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame
{
    internal class Program
    {
        // Method to generate a random number between 1 and 20
        static int Randomizer(Random randomNumber)
        {
            return randomNumber.Next(1, 21);
        }

        static void Main(string[] args)
        {
            // Create a new instance of the Random class
            Random myRandom = new Random();
            // Generate a random number using the Randomizer-method
            int rightValue = Randomizer(myRandom);
            // Initialize variables
            bool isNotNumber = true;
            int inputValue = 0;
            string stringInput;

            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 och 20. Kan du gissa vilket? Du får fem försök.");
            // Main game loop, with 5 attempts
            for (int numberOfGuesses = 5; numberOfGuesses > 0; numberOfGuesses--)
            {
                while (isNotNumber)
                {
                    try
                    {
                        // Read user input as a string and tries to convert the string to an integer
                        stringInput = Console.ReadLine();
                        inputValue = Convert.ToInt32(stringInput);
                        // Input is a valid number, exit the input loop
                        isNotNumber = false;
                    }
                    catch
                    {
                        // Invalid input (not a number)
                        Console.WriteLine("Du måste ange en siffra!");
                    }
                }
                if (inputValue < 1 || inputValue > 20)
                {
                    // Input is not within the range 1-20
                    Console.WriteLine("Du måste ange en siffra mellan 1 och 20!");
                    numberOfGuesses++;
                }
                else if (inputValue < rightValue && numberOfGuesses > 1)
                {
                    // Guess is too low, provide feedback
                    Console.WriteLine($"Tyvärr, du gissade för lågt! {numberOfGuesses - 1} gissning(ar) kvar!");
                }
                else if (inputValue > rightValue && numberOfGuesses > 1)
                {
                    // Guess is too high, provide feedback
                    Console.WriteLine($"Tyvärr, du gissade för högt! {numberOfGuesses - 1} gissning(ar) kvar!");
                }
                else if (inputValue == rightValue)
                {
                    // Correct guess, exit the game loop
                    Console.WriteLine("Wohoo! Du klarade det! Tryck på valfri knapp för att avsluta.");
                    numberOfGuesses = 0;
                }
                else if (numberOfGuesses == 1)
                {
                    // Out of attempts, display a message
                    Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök! Tryck på valfri knapp för att avsluta.");
                    numberOfGuesses = 0;
                }
                // Reset the flag to accept new input
                isNotNumber = true;
            }
            // Wait for a key press before exiting
            Console.ReadKey();
        }
    }
}
