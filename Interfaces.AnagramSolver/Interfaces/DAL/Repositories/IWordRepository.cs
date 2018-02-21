using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Core
{
    public interface IWordRepository
    {
        List<string> GetData();
        List<string> GetFilteredWords(string fragment);
        string FindWordByID(int wordID);
        int FindWordID(string word);
        void AddNewWord(string word);
        void UpdateWord(int wordID, string newWord);
        void DeleteWord(int wordID);

    }
}
