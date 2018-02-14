using Anagrams.EF.Core;
using Implementation.AnagramSolver.Model;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public class UserLogEFRepository : IUserLogRepository
    {
        public void AddUserLog(UserLogFull userLog)
        {
            using (var context = new AnagramsEntities())
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
            using (var context = new AnagramsEntities())
            {
                List<UserLog> userLogs = context.UserLogs.ToList();
                return userLogs.Select(a => new UserLogFull(a.IP_address, a.SearchTime, a.CachedWordID)).ToList();
            }
        }
    }
}
