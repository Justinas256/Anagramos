using Anagram.Core;
using Anagram.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Business
{
    public class UserLogService : IUserLogService
    {

        const int MAX_VIEW = 5;

        IUserLogRepository Repository;
        ICachedWordsService cachedWordsService;

        public UserLogService(IUserLogRepository repository, ICachedWordsService cachedWordService)
        {
            Repository = repository;
            cachedWordsService = cachedWordService;
        }

        public void AddNewLog(string ip, DateTime time, string cachedWord)
        {
            int cachedWordID = cachedWordsService.GetCachedWordID(cachedWord).Value;
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

        public void AddNewLogView(string ip, DateTime time, string cachedWord)
        {
            int? cachedWordID = cachedWordsService.GetCachedWordID(cachedWord);
            if (cachedWordID != null)
            {
                UserLogFull userLog = new UserLogFull(ip, time, cachedWordID.Value, "View");
                Repository.AddUserLog(userLog);
            }
           
        }

        public void AddNewLogDeleted(string ip, DateTime time, string cachedWord)
        {
            int? cachedWordID = cachedWordsService.GetCachedWordID(cachedWord);
            if (cachedWordID != null)
            {
                UserLogFull userLog = new UserLogFull(ip, time, cachedWordID.Value, "Delete");
                Repository.AddUserLog(userLog);
            }
            
        }

        public void AddNewLogUpdated(string ip, DateTime time, string cachedWord)
        {
            int? cachedWordID = cachedWordsService.GetCachedWordID(cachedWord);
            if (cachedWordID != null)
            {
                UserLogFull userLog = new UserLogFull(ip, time, cachedWordID.Value, "Update");
                Repository.AddUserLog(userLog);
            }
        }

        public void AddNewLogAdded(string ip, DateTime time, string cachedWord)
        {
            int? cachedWordID = cachedWordsService.GetCachedWordID(cachedWord);
            if (cachedWordID != null)
            {
                UserLogFull userLog = new UserLogFull(ip, time, cachedWordID.Value, "Add");
                Repository.AddUserLog(userLog);
            }
        }

        public bool IsPermittedToView(string ip)
        {
            int noOfViews = Repository.CountActionsByIP(ip, "View");
            int noOfUpdates = Repository.CountActionsByIP(ip, "Update");
            int noOfDeletes = Repository.CountActionsByIP(ip, "Delete");
            int noOfAdded = Repository.CountActionsByIP(ip, "Add");

            int count = MAX_VIEW - noOfViews - noOfDeletes + noOfUpdates + noOfAdded;
            if(count < 0)
            {
                return false;
            } else
            {
                return true;
            }
        }

    }
}
