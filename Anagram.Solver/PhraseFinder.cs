using Interfaces.AnagramSolver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Solver
{
    //many unused methods
    public class PhraseFinder : IAnagramSolver
    {

        public List<String> AllWords { private set; get; }

        public Dictionary<string, List<string>> DictionaryWords { private set; get; }

        public void Init(List<String> words)
        {
            AllWords = words;
            DictionaryWords = ListToDictionary(AllWords);
        }

        public List<string> FindWords(List<String> toFind)
        {
            if (toFind == null || toFind.Count < 1)
                return null;

            String combinedWord = "";
            foreach (String word in toFind)
                combinedWord += word;
            String sortedWord = SortLetters(combinedWord);

            Dictionary<string, List<string>> dictionary = DictionaryWords;

            if (dictionary.ContainsKey(sortedWord))
            {
                return dictionary[sortedWord];
            }

            return null;
        }

        Dictionary<string, List<string>>  ReduceDictionary (Dictionary<string, List<string>> dictionary, String sortedWord)
        {

            return null;
        }

        List<string> findRecursiveTwo(Dictionary<string, List<string>> dictionary, String sortedWord)
        {
            //String word = "";
            int length = sortedWord.Length;
            HashSet<String> tried = new HashSet<String>();

            for(int i = 4; i < length; i++)
            {

            }

            return null;

        }

        private Dictionary<string, List<string>> ListToDictionary(List<String> allWords)
        {
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            foreach (string word in allWords)
            {
                String sortedWord = SortLetters(word);
                if (words.ContainsKey(sortedWord))
                {
                    List<string> wordsList = words[sortedWord];
                    if (!wordsList.Contains(word))
                        wordsList.Add(word);
                }
                else
                {
                    List<string> wordsList = new List<string>();
                    wordsList.Add(word);
                    words.Add(sortedWord, wordsList);
                }
            }

            return words;
        }

        private Dictionary<int, List<string>> ListToSumDictionary(ArrayList allWords)
        {
            Dictionary<int, List<string>> wordsSum = new Dictionary<int, List<string>>();
            byte[] asciiBytes;
            int total;

            foreach (string word in allWords)
            {
                asciiBytes = Encoding.ASCII.GetBytes(word);
                total = 0;
                Array.ForEach(asciiBytes, delegate (byte i) { total += i; });

                if (wordsSum.ContainsKey(total))
                {
                    List<string> wordsList = wordsSum[total];
                    if (!wordsList.Contains(word))
                        wordsList.Add(word);
                }
                else
                {
                    List<string> wordsList = new List<string>();
                    wordsList.Add(word);
                    wordsSum.Add(total, wordsList);
                }
            }

            Console.WriteLine(wordsSum.Count);

            return wordsSum;
        }

        private String SortLetters(String word)
        {
            return String.Concat(word.OrderBy(c => c));
        }

    }

}
