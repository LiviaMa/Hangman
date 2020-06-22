using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class RandomWordGenerator:IWordGenerator
    {
        List<string> allWords = new List<string>() { "noodle", "food", "cheese" };
        public string GenerateWord()
        {
            var random = new Random();
            int index = random.Next(allWords.Count);
            string element = allWords[index];
            return element;
        }
    }
}
