using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver.Database
{
    public class CachedWordsEFRepository : ICachedWordsRepository
    {
        public string FindWordByID(int wordID)
        {
            using (var context = new AnagramsEntities())
            {
                return  context.Words.Find(wordID)?.Word1;
            }       
        }

        public int FindWordID(string word)
        {
            using (var context = new AnagramsEntities())
            {
                return context.Words
                    .Where(b => b.Word1 == word)
                    .FirstOrDefault().ID;
            }
        }

        public List<int> GetCachedAnagrams(int cachedWordID)
        {
            using (var context = new AnagramsEntities())
            {
                return context.CachedWords
                    .SingleOrDefault(b => b.CachedWordID == cachedWordID).Words.Select(b => b.ID).ToList();
            }
        }

        public string GetCachedWordByID(int cachedWordID)
        {
            using (var context = new AnagramsEntities())
            {
                return context.CachedWords.Find(cachedWordID).CachedWord1;
            }
        }

        public int GetCachedWordID(string word)
        {
            using (var context = new AnagramsEntities())
            {
                return context.CachedWords
                    .Where(b => b.CachedWord1 == word)
                    .FirstOrDefault().CachedWordID;
            }
        }

        public void InsertIntoCashedAnagrams(int cachedWordID, List<int> anagramsID)
        {
            using (var context = new AnagramsEntities())
            {
                var cachedWord = context.CachedWords.SingleOrDefault(b => b.CachedWordID == cachedWordID);
                if (cachedWord != null)
                {
                    cachedWord.Words = context.Words.Where(b => anagramsID.Contains(b.ID)).ToList();
                }
            }
        }

        public void InsertIntoCashedWords(string word)
        {
            using (var context = new AnagramsEntities())
            {
                var cachedWord = new CachedWord() { CachedWord1 = word };
                context.CachedWords.Add(cachedWord);
                context.SaveChanges();
            }
        }
    }
}
