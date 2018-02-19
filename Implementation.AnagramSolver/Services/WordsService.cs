using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver.Services
{
    public class WordsService
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
            if(word != null && word.Length > 1)
            {
                WordsRepository.AddNewWord(word);
            } else
            {
                throw new Exception("Invalid wrong");
            }
            
        }

        public void DeleteWord(int wordID)
        {
            try
            {
                WordsRepository.DeleteWord(wordID);
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteWord(string word)
        {
            try
            {
                int wordID = WordsRepository.FindWordID(word);
                WordsRepository.DeleteWord(wordID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWord(int wordID, string newWord)
        {
            if (newWord == null && newWord.Length < 2)
            {
                throw new Exception("Invalid wrong");
            }

            try
            {
                WordsRepository.UpdateWord(wordID, newWord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWord(string oldWord, string newWord)
        {
            if (oldWord == null || oldWord.Length < 2 || newWord == null || newWord.Length < 2)
            {
                throw new Exception("Invalid word!");
            }

            try
            {
                int wordID = WordsRepository.FindWordID(oldWord);
                UpdateWord(wordID, newWord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
