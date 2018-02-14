using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.AnagramSolver
{
    public interface ICachedWordsRepository
    {
        int GetCachedWordID(string word);
        string GetCachedWordByID(int cachedWordID);
        void InsertIntoCashedAnagrams(int cachedWordID, List<int> anagramsID);
        void InsertIntoCashedWords(string word);
        List<int> GetCachedAnagrams(int cachedWordID);
        int FindWordID(string word);
        string FindWordByID(int wordID);
    }
}
