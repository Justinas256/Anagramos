using Anagram.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Core
{
    public interface IUserLogService
    {
        void AddNewLog(string ip, DateTime time, string cachedWord);
        List<UserLogFull> GetAllLogs();
        List<UserLogFull> GetAllLogsAndAnagrams();
        void AddNewLogView(string ip, DateTime time, string cachedWord);
        void AddNewLogDeleted(string ip, DateTime time, string cachedWord);
        void AddNewLogUpdated(string ip, DateTime time, string cachedWord);
        void AddNewLogAdded(string ip, DateTime time, string cachedWord);
        bool IsPermittedToView(string ip);
    }
}
