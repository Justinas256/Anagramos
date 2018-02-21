using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Controllers;
using Shouldly;
using System.Web.Mvc;
using Anagram.Business;
using Anagram.Core;

namespace AnagramSolver.Tests.Controllers
{
    [TestFixture]
    class HomeControllerTest
    {
        private HomeController _homeController;
        private WordsService _wordsService;
        private CachedWordsService _cachedWordsService;
        private UserLogService _userLogService;
        private IAnagramSolver _anagramSolver;

        [SetUp]
        public void Setup()
        {
            _wordsService = Substitute.For<WordsService>(null, null);
            _cachedWordsService = Substitute.For<CachedWordsService>(null, null, null);
            _anagramSolver = Substitute.For<IAnagramSolver>();
            _userLogService = Substitute.For<UserLogService>(null, null);
            _homeController = new HomeController(_anagramSolver, _wordsService, _cachedWordsService, _userLogService);
        }

        [Test]
        public void FindWord_GetCorrectWords()
        {
            _wordsService.GetFilteredWords("nam").Returns(new List<string> { "namas", "namas2" });
            ViewResult result = (ViewResult)_homeController.FindWord("nam");
            result.Model.ShouldBe(new List<string> { "namas", "namas2" });
            
        }
    }
}
