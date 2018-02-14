using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.EFCF.Core.Model
{
    public class CachedWord
    {
        public CachedWord()
        {
            this.UserLogs = new HashSet<UserLog>();
            this.Words = new HashSet<Word>();
        }

        public int CachedWordID { get; set; }
        public string CachedWord1 { get; set; }

        public virtual ICollection<UserLog> UserLogs { get; set; }
        public virtual ICollection<Word> Words { get; set; }
    }
}