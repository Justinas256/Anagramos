
using Anagram.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Business
{
    public class CachedWordsService : ICachedWordsService
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

        public int? GetCachedWordID(string word)
        {
            return Repository.GetCachedWordID(word);
            /*
            int? result = Repository.GetCachedWordID(word);
            if(!nulable && result == null)
            {
                throw new Exception($"Could not find {word}");
            }
            return result;
            */
        }

        public string GetCachedWordByID(int cachedWordID)
        {
            return Repository.GetCachedWordByID(cachedWordID);
        }

        public List<int> FindCachedAnagrams(string word)
        {
            int? cachedWordId = this.GetCachedWordID(word);
            if (cachedWordId != null)
            {
                return Repository.GetCachedAnagrams(cachedWordId.Value);
            }
            return null;
        }

        public List<string> FindCachedAnagramsString (string word)
        {
            List<int> cachedAnagrams = FindCachedAnagrams(word);
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
            int? cachedWordId = Repository.GetCachedWordID(word);
            if (cachedWordId != null && anagrams != null && anagrams.Any())
            {
                List<int> anagramsID = new List<int>();
                int anagramId;
                foreach (string anagram in anagrams)
                {
                    anagramId = WordsRepository.FindWordID(anagram);
                    anagramsID.Add(anagramId);
                }
                Repository.InsertIntoCashedAnagrams(cachedWordId.Value, anagramsID);
            }
        }

        public List<string> FindAnagrams(string word)
        {
            List<string> anagrams = FindCachedAnagramsString(word);
            if (anagrams == null)
            {
                anagrams = Solver.FindWords(new List<String>() { word });
                //InsertCashedWords(word, anagrams);
            }
            return anagrams;
        }

    }
}
