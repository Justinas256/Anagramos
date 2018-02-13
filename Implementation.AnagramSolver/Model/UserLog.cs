using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver.Model
{
    public class UserLog
    {
        public string IP_address;
        public DateTime Time;
        public int CachedWordID;
        public string CachedWord;
        public List<string> Anagrams;

        public UserLog(string ip, DateTime time, int cachedWord)
        {
            IP_address = ip;
            Time = time;
            CachedWordID = cachedWord;
        }

    }
}
