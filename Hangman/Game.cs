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

       public Game()
        {
            Lives = 6;
            Word = GetRandomWord();
            HideWord();
        }
        static Game()
        {
            allWords = new List<string>() { "noodle", "food", "sound" };
        }
        
        public string GetRandomWord()
        {
            var random = new Random();
            int index = random.Next(allWords.Count);
            string element = allWords[index];
            return element;
        }
       
        public void GuessLetter(char letter)
        {
            int index;
            if (!Word.Contains(letter))
            {
                Lives--;
            }
            else
            {
                index = Word.IndexOf(letter);
                var sb = new StringBuilder(RevealedLetters);
                sb[index] = letter;
                ValidateInput(letter);
                RevealedLetters = sb.ToString();
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
            return true;
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
