using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public class CachedWordsService
    {

        ICachedWordsRepository Repository;
        IAnagramSolver Solver;
        IWordRepository WordsRepository;

        public CachedWordsService(ICachedWordsRepository repository, IWordRepository wordsRepository, IAnagramSolver solver)
        {
            Repository = repository;
            Solver = solver;
            WordsRepository = wordsRepository;
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
            if (cachedAnagrams != null)
            {
                List<string> anagramsString = new List<string>();
                string anagramString;
                foreach (int anagram in cachedAnagrams)
                {
                    anagramString = WordsRepository.FindWordByID(anagram);
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
                    anagramId = WordsRepository.FindWordID(anagram);
                    anagramsID.Add(anagramId);
                }
                Repository.InsertIntoCashedAnagrams(cachedWordId, anagramsID);
            }
        }

        public List<string> FindAnagrams(string word)
        {
            List<string> anagrams = FindCachedAnagramsString(word);
            if (anagrams == null)
            {
                anagrams = Solver?.FindWords(new List<String>() { word });
                //InsertCashedWords(word, anagrams);
            }
            return anagrams;
        }

    }
}
