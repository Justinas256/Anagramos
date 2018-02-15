using Anagrams.EFCF.Core.Context;
using Anagrams.EFCF.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    public class DatabaseEFCF : IDatabase
    {
        public void AddWordsToDatabase(List<string> words)
        {
            using (var context = new AnagramCFContext())
            {
                context.Words.AddRange(words.Select(a => new Word() { Word1 = a }));
                context.SaveChanges();
            }
        }

        public void DeleteTable(string table)
        {
            using (var context = new AnagramCFContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM " + table);
            }
        }
    }
}
