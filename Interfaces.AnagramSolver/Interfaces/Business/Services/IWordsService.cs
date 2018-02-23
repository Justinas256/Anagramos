using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Core
{
    public interface IWordsService
    {
        List<string> GetData();
        List<string> GetFilteredWords(string fragment);
        void AddNewWord(string word);
        void DeleteWord(int wordID);
        void DeleteWord(string word);
        void UpdateWord(int wordID, string newWord);
        void UpdateWord(string oldWord, string newWord);
        Task<List<string>> GetDataAsync();
    }
}
