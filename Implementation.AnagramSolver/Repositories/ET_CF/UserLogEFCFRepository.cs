using Anagrams.EFCF.Core.Context;
using Anagrams.EFCF.Core.Model;
using Implementation.AnagramSolver.Model;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
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
                    SearchTime = userLog.Time
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
                return userLogs.Select(a => new UserLogFull(a.IP_address, a.SearchTime, a.CachedWordID)).ToList();
            }
        }
    }
}
