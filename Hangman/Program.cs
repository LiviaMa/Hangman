using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWordGenerator wordGenerator = new RandomWordGenerator();
            var game = new Game(wordGenerator);

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("You have " + game.Lives + " lives!");
            Console.WriteLine("Fist word is:");
            for (int i = 0; i < game.RevealedLetters.Length; i++)
            {
                Console.Write(game.RevealedLetters[i] + " ");
            }
            Console.WriteLine();

            while (game.Lives >= 1)
            {
                Console.WriteLine("Pick one of the options below" + "\n1.Guess a letter\n2.Exit");
                Console.WriteLine();
                Console.WriteLine("Your choice is:");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter your guess letter");
                    char letter = Console.ReadLine().ToCharArray()[0];
                    game.GuessLetter(letter);

                    for (int i = 0; i < game.RevealedLetters.Length; i++)
                    {
                        Console.Write(game.RevealedLetters[i] + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Lives: " + game.Lives);

                    if (!game.IsGameRunning())
                    {
                        Console.WriteLine("Game over!" + " You lost!");
                    }
                }
                if (input == "2")
                {
                    break;
                }
            }
        }
    }
}
