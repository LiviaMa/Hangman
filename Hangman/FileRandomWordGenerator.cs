using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class FileRandomWordGenerator:IWordGenerator
    {
        List<string> allWords = GetWordsFrom("allWords.txt");
        
        public static List<string> GetWordsFrom(string filepath)
        {
            List<string> allWords = new List<string>();
            using (StreamReader dataFromFile = new StreamReader(filepath))
            {
                string line = dataFromFile.ReadLine();

                while (line != null)
                {
                    string[] splitWord = line.Split('|');
                    for (int i = 0; i < splitWord.Length; i++)
                    {
                        allWords.Add(splitWord[i]);
                    }
                }
            }
            return allWords;
        }
        public string GenerateWord()
        {
            var random = new Random();
            int index = random.Next(allWords.Count);
            string element = allWords[index];
            return element;
        }
        
    }
}
