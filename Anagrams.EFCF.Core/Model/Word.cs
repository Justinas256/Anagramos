using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Word1 { get; set; }

        public virtual ICollection<CachedWord> CachedWords { get; set; }
    }
}
