using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class Game
    {
        public int Lives { get; set; }
        public string Word { get; set; }

        public string RevealedLetters { get; set; }

        public static List<string> allWords;

       public Game(IWordGenerator generator)
        {
            Lives = 6;
            Word = generator.GenerateWord();
            HideWord();
        }
       
        static Game()
        {
            allWords = new List<string>() { "noodle", "food", "sound" };
        }
               
        public void GuessLetter(char letter)
        {
            if (!Word.Contains(letter))
            {
                Lives--;
            }
            else
            {
                int index = Word.IndexOf(letter);

                while (index != -1)
                {
                    var sb = new StringBuilder(RevealedLetters);
                    sb[index] = letter;
                    ValidateInput(letter);
                    RevealedLetters = sb.ToString();
                    index = Word.IndexOf(letter, index + 1);
                }
            }
        }

        public void HideWord()
        {
            for (int i = 0; i < Word.Length; i++)
            {
                RevealedLetters += '_';
            }
        }
        public bool IsGameRunning()
        {
            if (Lives >= 1)
            {
                return true;
            }
            return false;
        }

        private bool IsValidInputFormat(char input)
        {
            return Regex.IsMatch(input.ToString(), @"^[a-zA-Z]+$");
        }

        public void ValidateInput(char input)
        {
            if(!IsValidInputFormat(input))
            {
                Console.WriteLine("Please enter valid input!");
            }
        }
    }
}
