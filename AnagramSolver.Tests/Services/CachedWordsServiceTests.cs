using Implementation.AnagramSolver;
using Interfaces.AnagramSolver;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace AnagramSolver.Tests.Services
{
    [TestFixture]
    class CachedWordsServiceTests
    {
        private ICachedWordsRepository _cachedWordsRepository;
        private IWordRepository _wordRepository;
        private IAnagramSolver _anagramSolver;
        private CachedWordsService _cachedWordsService;
        

        [SetUp]
        public void Setup()
        {
            _cachedWordsRepository = Substitute.For<ICachedWordsRepository>();
            _wordRepository = Substitute.For<IWordRepository>();
            _anagramSolver = Substitute.For<IAnagramSolver>();
            _cachedWordsService = new CachedWordsService(_cachedWordsRepository, _wordRepository, _anagramSolver);
        }

        [Test]
        public void FindCachedAnagrams_ShouldGetCorrectAnagrams()
        {
            _cachedWordsRepository.GetCachedWordID("alus").Returns(1);
            _cachedWordsRepository.GetCachedAnagrams(1).Returns(new List<int> { 1, 2 });

            var result = _cachedWordsService.FindCachedAnagrams("alus");
            result.ShouldBe(new List<int> { 1, 2 });
        }

        [Test]
        public void FindCachedAnagramsString_ShouldGetCorrectAnagrams()
        {
            _cachedWordsRepository.GetCachedWordID("alus").Returns(1);
            _cachedWordsRepository.GetCachedAnagrams(1).Returns(new List<int> { 1, 2 });
            _wordRepository.FindWordByID(1).Returns("alus");
            _wordRepository.FindWordByID(2).Returns("sula");
            _wordRepository.FindWordByID(3).Returns("sulas");

            var result = _cachedWordsService.FindCachedAnagramsString("alus");
            result.ShouldBe(new List<string> { "alus", "sula" });
        }

        /*
        [Test]
        public void FindAnagrams_NoCachedAnagrams_ShouldFindAllAnagrams()
        {
            _anagramSolver.FindWords(new List<String>() { "sula" }).Returns(new List<string>() { "alus" });
            _cachedWordsRepository.GetCachedWordID("sula").Returns(-1);

            var result = _cachedWordsService.FindAnagrams("sula");
            result.ShouldBe(new List<string> { "alus"});
        }
        */



    }
}
