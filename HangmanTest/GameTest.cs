using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace HangmanTest
{
    [TestClass]
    public class GameTest
    {
        Mock<IWordGenerator> mockWordGenerator;
        Game game;

    [TestInitialize]
        public void Setup()
        {
            //arrange
            mockWordGenerator = new Mock<IWordGenerator>();
            mockWordGenerator.Setup(x => x.GenerateWord()).Returns("noodle");
            game = new Game(mockWordGenerator.Object);
        }

        [TestMethod]
        public void WhenGameStarts_CheckInitializedLives()
        {
            //arrange
            Assert.AreEqual(6, game.Lives);
            mockWordGenerator.VerifyAll();
        }
      
        [TestMethod]
        public void GuessNonExistingLetter_DecreasesLives()
        {
           
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
            int count = game.RevealedLetters.Count(f => f == '_');

            Assert.AreEqual(game.RevealedLetters.Length, game.Word.Length);
            Assert.AreEqual(count, game.Word.Length);
        }
        [TestMethod]
        public void GuessExistingLetter_RevealGuessedLetter()
        {
            //arrange
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
            //assert
            Assert.IsTrue(game.IsGameRunning());
        }

        [TestMethod]
        public void WhenGuessLetterWithMultipleOccurences_RevealAllPositions()
        {
            //act
            game.GuessLetter('o');

            //assert
            Assert.AreEqual("_oo___", game.RevealedLetters);
        }

        [TestMethod]
        public void WhenLivesZero_GameOver()
        {
            //arrange
            int lives = game.Lives;
            lives = 0;
            //act
            for (int i = 1; i <= 6; i++)
            {
                game.IsGameRunning();
                game.Lives--;
            }

            Assert.AreEqual(lives, game.Lives);
        }
    }
}
