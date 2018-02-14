using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.EFCF.Core.Model
{
    public class Word
    {
        public Word()
        {
            this.CachedWords = new HashSet<CachedWord>();
        }

        public int ID { get; set; }
        public string Word1 { get; set; }

        public virtual ICollection<CachedWord> CachedWords { get; set; }
    }
}
