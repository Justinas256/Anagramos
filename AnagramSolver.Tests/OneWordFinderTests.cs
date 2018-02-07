using Implementation.AnagramSolver;
using Interfaces.AnagramSolver;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.Tests
{
    [TestFixture]
    public class OneWordFinderTests
    {
        public ArrayList allWords;
        public ArrayList toFind;

        [Test]
        public void FindWords_NoWordsList_ReturnNull()
        {
            ArrayList words = new ArrayList();
            words.Add("alus");
            IAnagramSolver oneWordFinder = new OneWordFinder();
            Assert.IsNull(oneWordFinder.FindWords(null, words));
        }

        [Test]
        public void FindWords_NoListOfWordsToFind_ReturnNull()
        {
            ArrayList words = new ArrayList();
            words.Add("alus");
            IAnagramSolver oneWordFinder = new OneWordFinder();
            Assert.IsNull(oneWordFinder.FindWords(words, null));
        }

        [Test]
        public void FindWords_ToAnogram_CorrectWords()
        {
            ArrayList wordsToFind = new ArrayList() { "alus" };
            ArrayList allWords = new ArrayList() { "alus", "sula", "pele" };
            List<string> correctWords = new List<string>() { "alus", "sula"};
            IAnagramSolver oneWordFinder = new OneWordFinder();
            List<string> findedWords = oneWordFinder.FindWords(allWords, wordsToFind);
            Assert.IsTrue(findedWords.All(correctWords.Contains));
        }

        [Test]
        public void Should_Find_Correct_Words()
        {
            ArrayList wordsToFind = new ArrayList() { "rasa" };
            ArrayList allWords = new ArrayList() { "aras", "sula", "pele" };
            String correctWord = "aras";
            IAnagramSolver oneWordFinder = new OneWordFinder();
            List<string> findedWords = oneWordFinder.FindWords(allWords, wordsToFind);
            if (findedWords == null || findedWords.Count != 1)
                Assert.Fail();
            else
                correctWord.ShouldBe(findedWords[0]);
        }


    }
}
