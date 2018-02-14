using Anagrams.EF.Core;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver.Database
{
    public class WordsEFRepository : IWordRepository
    {
        public List<string> GetData()
        {
            using (var context = new AnagramsEntities())
            {
                return context.Words.Select(b => b.Word1).ToList();
            }
        }

        public List<string> GetFilteredWords(string fragment)
        {
            using (var context = new AnagramsEntities())
            {
                return context.Words.Where(b => b.Word1.StartsWith(fragment)).Select(a => a.Word1).ToList();
            }
        }
    }
}
