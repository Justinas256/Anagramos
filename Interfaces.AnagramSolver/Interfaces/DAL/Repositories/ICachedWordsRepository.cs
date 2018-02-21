using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Core
{
    public interface ICachedWordsRepository
    {
        List<int> GetCachedAnagrams(int cachedWordID);
        int? GetCachedWordID(string word);
        string GetCachedWordByID(int cachedWordID);
        void InsertIntoCashedAnagrams(int cachedWordID, List<int> anagramsID);
        void InsertIntoCashedWords(string word);
        
    }
}
