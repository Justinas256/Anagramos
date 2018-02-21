using Anagram.Core;
using Anagrams.EF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.EF.Core
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

        public string FindWordByID(int wordID)
        {
            using (var context = new AnagramsEntities())
            {
                return context.Words.Find(wordID)?.Word1;
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

        public void AddNewWord(string word)
        {
            using (var context = new AnagramsEntities())
            {
                var newWord = new Word() { Word1 = word };
                context.Words.Add(newWord);
                context.SaveChanges();
            }
        }

        public void DeleteWord(int wordID)
        {
            using (var context = new AnagramsEntities())
            {
                var itemToRemove = context.Words.SingleOrDefault(x => x.ID == wordID);
                if (itemToRemove != null)
                {
                    context.Words.Remove(itemToRemove);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Such word doesnt exist");
                }
            }
        }

        public void UpdateWord(int wordID, string newWord)
        {
            using (var context = new AnagramsEntities())
            {
                var itemToUpdate = context.Words.SingleOrDefault(x => x.ID == wordID);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Word1 = newWord;
                    itemToUpdate.CachedWords = null;
                    context.SaveChanges();
                } else
                {
                    throw new Exception("Such word doesnt exist");
                }
            }
        }
    }
}
