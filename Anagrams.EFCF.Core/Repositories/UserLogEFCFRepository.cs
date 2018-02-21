using Anagram.Core;
using Anagram.Core.Model;
using Anagrams.EFCF.Core.Context;
using Anagrams.EFCF.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.EFCF.Core
{
    public class UserLogEFCFRepository : IUserLogRepository
    {
        public void AddUserLog(UserLogFull userLog)
        {
            using (var context = new AnagramCFContext())
            {
                var newUserLog = new UserLog()
                {
                    IP_address = userLog.IP_address,
                    CachedWordID = userLog.CachedWordID,
                    SearchTime = userLog.Time,
                    Action = userLog.Action
                };
                context.UserLogs.Add(newUserLog);
                context.SaveChanges();
            }
        }

        public List<UserLogFull> GetUserLogs()
        {
            using (var context = new AnagramCFContext())
            {
                List<UserLog> userLogs = context.UserLogs.ToList();
                return userLogs.Select(a => new UserLogFull(a.IP_address, a.SearchTime, a.CachedWordID, a.Action)).ToList();
            }
        }

        public int CountActionsByIP(string ip_address, string action)
        {
            using (var context = new AnagramCFContext())
            {
                List<UserLog> userLogs = context.UserLogs.ToList();
                return userLogs.Where(a => a.IP_address == ip_address && a.Action == action).Count();
            }
        }

    }
}
