using Implementation.AnagramSolver.Model;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver.Database
{
    public class UserLogService
    {
        IUserLogRepository Repository;
        CachedWordsService cachedWordsService;

        public UserLogService(IUserLogRepository repository, CachedWordsService cachedWordService)
        {
            Repository = repository;
            cachedWordsService = cachedWordService;
        }

        public void AddNewLog(string ip, DateTime time, string cachedWord)
        {
            int cachedWordID = cachedWordsService.GetCachedWordID(cachedWord);
            UserLogFull userLog = new UserLogFull(ip, time, cachedWordID);
            Repository.AddUserLog(userLog);
        }

        public List<UserLogFull> GetAllLogs()
        {
            return Repository.GetUserLogs();
        }

        public List<UserLogFull> GetAllLogsAndAnagrams()
        {
            List<UserLogFull> logs = Repository.GetUserLogs();
            foreach(UserLogFull log in logs)
            {
                log.CachedWord = cachedWordsService.GetCachedWordByID(log.CachedWordID);
                log.Anagrams = cachedWordsService.FindCachedAnagramsString(log.CachedWord);
            }
            return logs;
        }

    }
}
