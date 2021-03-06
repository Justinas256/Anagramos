﻿using Anagram.Business;
using Anagram.Core;
using Anagrams.Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Web.Controllers;

namespace AnagramSolver.Tests
{
    [TestFixture]
    class AnagramsApiControllerTests
    {
        IAnagramSolver Solver;

        [SetUp]
        public void Setup()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            IWordRepository fileReader = new FileReader(path);
            Solver = new OneWordFinder(fileReader.GetData());
        }

        [Test]
        public async Task GetAnagram_PassWord_GetCorrectAnagram()
        {
            var controller = new AnagramsApiController(Solver);
            IHttpActionResult actionResult = await controller.GetAnagram("alus");
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            Assert.AreEqual(contentResult.Content, "Founded: alus, sula");
        }
    }
}
