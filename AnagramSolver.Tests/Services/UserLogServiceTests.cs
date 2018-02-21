using NSubstitute;
using NUnit.Framework;
using System;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anagram.Core;
using Anagram.Business;
using Anagram.Core.Model;

namespace AnagramSolver.Tests.Services
{
    [TestFixture]
    class UserLogServiceTests
    {
        private IUserLogRepository _userLogRepository;
        private ICachedWordsService _cachedWordsService;
        private UserLogService _userLogService;

        [SetUp]
        public void Setup()
        {
            _userLogRepository = Substitute.For<IUserLogRepository>();
            _cachedWordsService = Substitute.For<ICachedWordsService>();
            _userLogService = new UserLogService(_userLogRepository, _cachedWordsService);
        }

        [Test]
        public void GetAllLogs_ShouldGetAllIpAddresses()
        {
            _userLogRepository.GetUserLogs().Returns(new List<UserLogFull> { new UserLogFull("1", new DateTime(), 1),
                new UserLogFull("2", new DateTime(), 2)} );

            var result = _userLogService.GetAllLogs();

            result.ShouldNotBeNull();
            result.Select(a => a.IP_address).ToList().ShouldBe(new List<string> { "1", "2" });

            _userLogRepository.Received().GetUserLogs();
        }

        [Test]
        public void GetAllLogs_ShouldGetAllLogs()
        {
            _userLogRepository.GetUserLogs().Returns(new List<UserLogFull> { new UserLogFull("1", new DateTime(100), 1),
                new UserLogFull("2", new DateTime(200), 2)});
            var listOfLogs = new List<UserLogFull> { new UserLogFull("1", new DateTime(100), 1),
                new UserLogFull("2", new DateTime(200), 2) };

            var result = _userLogService.GetAllLogs();

            result.ShouldNotBeNull();

            result.Select(a => a.IP_address).ShouldBe(listOfLogs.Select(b => b.IP_address));
            result.Select(a => a.Time).ShouldBe(listOfLogs.Select(b => b.Time));
            result.Select(a => a.CachedWordID).ShouldBe(listOfLogs.Select(b => b.CachedWordID));
        }

        [Test]
        public void IsPermittedToView_NotPermitted()
        {
            _userLogRepository.CountActionsByIP("0", "View").Returns(20);
            _userLogRepository.CountActionsByIP("0", "Update").Returns(10);
            _userLogRepository.CountActionsByIP("0", "Delete").Returns(10);
            _userLogRepository.CountActionsByIP("0", "Add").Returns(10);

            _userLogService.IsPermittedToView("0").ShouldBe(false);
        }

        [Test]
        public void IsPermittedToView_Permitted()
        {
            _userLogRepository.CountActionsByIP("0", "View").Returns(5);
            _userLogRepository.CountActionsByIP("0", "Update").Returns(10);
            _userLogRepository.CountActionsByIP("0", "Delete").Returns(10);
            _userLogRepository.CountActionsByIP("0", "Add").Returns(10);

            _userLogService.IsPermittedToView("0").ShouldBe(true);
        }

        [Test]
        public void AddNewLogView_AddedToDatabase()
        {
            _cachedWordsService.GetCachedWordID(Arg.Any<string>()).Returns(1);
            _userLogService.AddNewLogView("1", new DateTime(), "la");
            _userLogRepository.Received().AddUserLog(Arg.Any<UserLogFull>());
        }

    }
}
