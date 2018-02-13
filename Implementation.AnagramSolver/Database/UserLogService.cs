using Implementation.AnagramSolver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver.Database
{
    public class UserLogService
    {
        UserLogRepository Repository;
        CachedWordsService cachedWordsService;

        public UserLogService(UserLogRepository repository)
        {
            Repository = repository;
            cachedWordsService = new CachedWordsService(new CachedWordsRepository());
        }

        public void AddNewLog(string ip, DateTime time, string cachedWord)
        {
            int cachedWordID = cachedWordsService.GetCachedWordID(cachedWord);
            UserLog userLog = new UserLog(ip, time, cachedWordID);
            Repository.AddUserLog(userLog);
        }

        public List<UserLog> GetAllLogs()
        {
            return Repository.GetUserLogs();
        }

        public List<UserLog> GetAllLogsAndAnagrams()
        {
            List<UserLog> logs = Repository.GetUserLogs();
            foreach(UserLog log in logs)
            {
                log.CachedWord = cachedWordsService.GetCachedWordByID(log.CachedWordID);
                log.Anagrams = cachedWordsService.FindCachedAnagramsString(log.CachedWord);
            }
            return logs;
        }

    }
}
