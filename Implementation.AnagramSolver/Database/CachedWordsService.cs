using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public class CachedWordsService
    {

        CachedWordsSQLRepository Repository;

        public CachedWordsService(CachedWordsSQLRepository repository)
        {
            Repository = repository;
        }

        public int GetCachedWordID(string word)
        {
            return Repository.GetCachedWordID(word);
        }

        public string GetCachedWordByID(int cachedWordID)
        {
            return Repository.GetCachedWordByID(cachedWordID);
        }

        public List<int> FindCachedAnagrams(string word)
        {
            int cachedWordId = this.GetCachedWordID(word);
            if (cachedWordId == -1)
            {
                return null;
            }
            else
            {
                return Repository.GetCachedAnagrams(cachedWordId);
            }
        }

        public List<string> FindCachedAnagramsString (string word)
        {
            List<int> cachedAnagrams = this.FindCachedAnagrams(word);
            int cachedWordId = Repository.GetCachedWordID(word);
            if (cachedAnagrams != null)
            {
                List<string> anagramsString = new List<string>();
                string anagramString;
                foreach (int anagram in cachedAnagrams)
                {
                    anagramString = Repository.FindWordByID(anagram);
                    anagramsString.Add(anagramString);
                }
                return anagramsString;
            }
            return null;
        }

        public void InsertCashedWords(string word, List<string> anagrams)
        {
            Repository.InsertIntoCashedWords(word);
            int cachedWordId = Repository.GetCachedWordID(word);
            if (cachedWordId != -1 && anagrams != null && anagrams.Any())
            {
                List<int> anagramsID = new List<int>();
                int anagramId;
                foreach (string anagram in anagrams)
                {
                    anagramId = Repository.FindWordID(anagram);
                    anagramsID.Add(anagramId);
                }
                Repository.InsertIntoCashedAnagrams(cachedWordId, anagramsID);
            }
        }


        //-------not used------
        /*
        public void InsertIntoCashedWords(string word, List<string> anagrams)
        {
            int anagramId;
            List<int> anagramsID = new List<int>();
            foreach (string anagram in anagrams)
            {
                anagramId = Repository.FindWordID(anagram);
                anagramsID.Add(anagramId);
            }
            Repository.InsertIntoCashedWords(word, anagramsID);
        }

        public List<int> FindCachedWords(string word)
        {
            int wordId = Repository.FindWordID(word);
            if (wordId == 0)
            {
                return null;
            }
            else
            {
                return Repository.FindCachedWords(wordId);
            }
        }

        public string FindWordByID(int wordID)
        {
            return Repository.FindWordByID(wordID);
        }
        */

    }
}
