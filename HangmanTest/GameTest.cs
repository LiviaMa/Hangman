using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using System.Collections.Generic;
using System.Linq;

namespace HangmanTest
{
    [TestClass]
    public class GameTest
    {
       
        [TestMethod]
        public void WhenGameStarts_CheckInitializedLives()
        {
            //arrange
            var game = new Game();
            Assert.AreEqual(6, game.Lives);

        }
        [TestMethod]
        public void WhenGameStarts_ValidateChoosedWord()
        {
            //arrange
            var game = new Game();

            //assert
            Assert.IsTrue(Game.allWords.Contains(game.Word));
            
        }
        [TestMethod]
        public void GuessNonExistingLetter_DecreasesLives()
        {
            //arrange
            var game = new Game();

            //find a letter not contained in chosen word
            char letter;
            for (letter = 'a'; letter <= 'z'; letter++)
            {
                if (!game.Word.Contains(letter))
                {
                    break;
                }
            }

            //act
            game.GuessLetter(letter);

            //assert
            Assert.AreEqual(5, game.Lives);
        }
        [TestMethod]
        public void GuessExistingLetter_DoesNotDecreaseLives()
        {
            //arrange
            var game = new Game();

            //find a letter contained in chosen word
            char letter;
            for (letter = 'a'; letter <= 'z'; letter++)
            {
                if (game.Word.Contains(letter))
                {
                    break;
                }
            }
            
            //act
            game.GuessLetter(letter);

            //assert
            Assert.AreEqual(6, game.Lives);
        }
        [TestMethod]
        public void WhenGameBegins_CheckLettersHidden()
        {   
            //arrange
            var game = new Game();
            int count = game.RevealedLetters.Count(f => f == '_');

            Assert.AreEqual(game.RevealedLetters.Length, game.Word.Length);
            Assert.AreEqual(count, game.Word.Length);

        }
        [TestMethod]
        public void GuessExistingLetter_RevealGuessedLetter()
        {
            //arrange
            var game = new Game();
            char letter;
            for (letter = 'a'; letter <= 'z'; letter++)
            {
                if (game.Word.Contains(letter))
                {
                    break;
                }
            }
            //act
            game.GuessLetter(letter);

            //assert
            int countOccurencesRevealed = game.RevealedLetters.Count(f => f == letter);
            int countOccurencesWord = game.Word.Count(f => f == letter);

            Assert.AreEqual(countOccurencesWord, countOccurencesRevealed);
        }
        [TestMethod]
        public void WhenGameStarts_IsGameRunning()
        {
            //arrange
            var game = new Game();

            //assert
            Assert.IsTrue(game.IsGameRunning());

        }

        [TestMethod]
        public void WhenGuessLetter_PutLetterOnAllPositionsForEachOccurance()
        {
            //arrange
            var game = new Game();

            //act

        }

        [TestMethod]
        public void WhenLivesZero_GameOver()
        {
            //arrange
            var game = new Game();
            
            //act

        }
    }
}
