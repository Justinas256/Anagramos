using Anagram.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Business
{
    public class WordsService : IWordsService
    {
        IWordRepository WordsRepository;
        ICachedWordsRepository CachedWordsRepository;

        public WordsService(IWordRepository wordsRepository, ICachedWordsRepository cachedWordsRepository)
        {
            WordsRepository = wordsRepository;
            CachedWordsRepository = cachedWordsRepository;
        }

        public List<string> GetData()
        {
            return WordsRepository.GetData();
        }

        public List<string> GetFilteredWords(string fragment)
        {
            return WordsRepository.GetFilteredWords(fragment);
        }

        public void AddNewWord(string word)
        {
            WordsRepository.AddNewWord(word);
            
        }

        public void DeleteWord(int wordID)
        {
            WordsRepository.DeleteWord(wordID);
        }

        public void DeleteWord(string word)
        {
            if (word == null || word.Length < 2)
            {
                throw new Exception("Invalid word!");
            }

            int wordID = WordsRepository.FindWordID(word);
            WordsRepository.DeleteWord(wordID);
        }

        public void UpdateWord(int wordID, string newWord)
        {
            if (newWord == null && newWord.Length < 2)
            {
                throw new Exception("Invalid wrong");
            }

            WordsRepository.UpdateWord(wordID, newWord);

        }

        public void UpdateWord(string oldWord, string newWord)
        {
            if (oldWord == null || oldWord.Length < 2 || newWord == null || newWord.Length < 2)
            {
                throw new Exception("Invalid word!");
            }

            int wordID = WordsRepository.FindWordID(oldWord);
            UpdateWord(wordID, newWord);
        }
    }
}
