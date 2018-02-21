using Anagram.Business;
using Anagram.Core;
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
            var toFind = new List<string>();
            toFind.Add("alus");
            IAnagramSolver oneWordFinder = new OneWordFinder(null);
            Assert.IsNull(oneWordFinder.FindWords(toFind));
        }

        [Test]
        public void FindWords_NoListOfWordsToFind_ReturnNull()
        {
            List<String> words = new List<String>();
            words.Add("alus");
            IAnagramSolver oneWordFinder = new OneWordFinder(words);
            Assert.IsNull(oneWordFinder.FindWords(null));
        }

        [Test]
        public void FindWords_ToAnogram_CorrectWords()
        {
            List<String> wordsToFind = new List<String>() { "alus" };
            List<String> allWords = new List<String>() { "alus", "sula", "pele" };
            List<string> correctWords = new List<string>() { "alus", "sula"};
            IAnagramSolver oneWordFinder = new OneWordFinder(allWords);
            List<string> findedWords = oneWordFinder.FindWords(wordsToFind);
            Assert.IsTrue(findedWords.All(correctWords.Contains));
        }

        [Test]
        public void Should_Find_Correct_Words()
        {
            List<String> wordsToFind = new List<String>() { "rasa" };
            List<String> allWords = new List<String>() { "aras", "sula", "pele" };
            String correctWord = "aras";
            IAnagramSolver oneWordFinder = new OneWordFinder(allWords);
            List<string> findedWords = oneWordFinder.FindWords(wordsToFind);
            correctWord.ShouldBe(findedWords.Single());
        }


    }
}
