using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.EFCF.Core.Model
{
    public class UserLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string IP_address { get; set; }
        public int CachedWordID { get; set; }
        public System.DateTime SearchTime { get; set; }

        public virtual CachedWord CachedWord { get; set; }
    }
}
