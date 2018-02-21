using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Anagram.Core;
using Anagram.Business;

namespace AnagramSolver.Tests.Services
{
    [TestFixture]
    class WordsServiceTests
    {
        private IWordRepository _wordRepository;
        private ICachedWordsRepository _cachedWordsRepository;
        private WordsService _wordsService;

        [SetUp]
        public void Setup()
        {
            _cachedWordsRepository = Substitute.For<ICachedWordsRepository>();
            _wordRepository = Substitute.For<IWordRepository>();
            _wordsService = new WordsService(_wordRepository, _cachedWordsRepository);
        }

        [Test]
        public void GetFilteredWords_ShouldGetAllFilteredWords()
        {
            _wordRepository.GetFilteredWords("nam").Returns(new List<string> { "namas", "namas2" });
            _wordsService.GetFilteredWords("nam").ShouldBe(new List<string> { "namas", "namas2" });
        }

        [Test]
        public void GetData_ShouldGetAllWords()
        {
            _wordRepository.GetData().Returns(new List<string> { "namas", "namas2" });
            _wordsService.GetData().ShouldBe(new List<string> { "namas", "namas2" });
        }
    }
}
