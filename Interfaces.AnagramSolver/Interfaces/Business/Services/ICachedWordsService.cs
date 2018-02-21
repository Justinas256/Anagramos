using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Core
{
    public interface ICachedWordsService
    {
        int? GetCachedWordID(string word);
        string GetCachedWordByID(int cachedWordID);
        List<int> FindCachedAnagrams(string word);
        List<string> FindCachedAnagramsString(string word);
        void InsertCashedWords(string word, List<string> anagrams);
        List<string> FindAnagrams(string word);
    }
}
