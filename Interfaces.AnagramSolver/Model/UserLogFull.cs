using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver.Model
{
    public class UserLogFull
    {
        public string IP_address;
        public DateTime Time;
        public int CachedWordID;
        public string CachedWord;
        public List<string> Anagrams;
        public string Action;

        public UserLogFull(string ip, DateTime time, int cachedWord)
        {
            IP_address = ip;
            Time = time;
            CachedWordID = cachedWord;
        }

        public UserLogFull(string ip, DateTime time, int cachedWord, string action) : this(ip, time, cachedWord)
        {
            Action = action;
        }

    }
}
