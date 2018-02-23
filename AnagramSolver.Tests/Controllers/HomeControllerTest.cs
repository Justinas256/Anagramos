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
        private IWordsService _wordsService;
        private ICachedWordsService _cachedWordsService;
        private IUserLogService _userLogService;
        private IAnagramSolver _anagramSolver;

        [SetUp]
        public void Setup()
        {
            _wordsService = Substitute.For<IWordsService>();
            _cachedWordsService = Substitute.For<ICachedWordsService>();
            _anagramSolver = Substitute.For<IAnagramSolver>();
            _userLogService = Substitute.For<IUserLogService>();
            _homeController = new HomeController(_anagramSolver, _wordsService, _cachedWordsService, _userLogService);
        }

        [Test]
        public async Task FindWord_GetCorrectWords()
        {
            _wordsService.GetFilteredWords("nam").Returns(new List<string> { "namas", "namas2" });
            ViewResult result = await _homeController.FindWord("nam");
            result.ViewData.Values.ShouldBe(new List<List<string>> { new List<string> { "namas", "namas2" } });
        }

        [Test]
        public async Task Anagram_IsPermitted_GetCorrectAnagrams()
        {
            _userLogService.IsPermittedToView(Arg.Any<string>()).Returns(true);
            _cachedWordsService.FindAnagrams("alus").Returns(new List<string> { "sula", "alus" });

            ViewResult result = await _homeController.Anagram("alus");
            result.ViewData.Values.ShouldBe(new List<List<string>> { new List<string> { "sula", "alus" } });
        }

        [Test]
        public async Task Anagram_INotPermitted_RetuenNotPermitted()
        {
            _userLogService.IsPermittedToView(Arg.Any<string>()).Returns(false);
            //_cachedWordsService.FindAnagrams("alus").Returns(new List<string> { "sula", "alus" });

            ViewResult result = await _homeController.Anagram("alus");
            result.ViewData.Values.ShouldBe(new List<object> { false });
        }

        [Test]
        public async Task Anagram_GetView_IndexView()
        {
            ViewResult result = await _homeController.Anagram("alus");
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Index_GetView_IndexView()
        {
            var result = _homeController.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }

    }
}
