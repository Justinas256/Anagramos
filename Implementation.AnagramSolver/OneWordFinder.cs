using Interfaces.AnagramSolver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public class OneWordFinder : IAnagramSolver
    {
        public List<string> FindWords(ArrayList allWords, ArrayList toFind)
        {
            if (toFind == null || toFind.Count < 1 || allWords == null || allWords.Count == 0)
                return null;

            String sortedWord = SortLetters(toFind[0].ToString());

            Dictionary<string, List<string>> dictionary = ListToDictionary(allWords);

            if (dictionary.ContainsKey(sortedWord))
            {
                return dictionary[sortedWord];
            }

            return null;
        }

        private String SortLetters(String word)
        {
            return String.Concat(word.OrderBy(c => c));
        }

        private HashSet<String> ListTohashSet(ArrayList allWords)
        {
            HashSet<String> words = new HashSet<String>();
            foreach(string word in allWords)
                words.Add(SortLetters(word));
            return words;
        }

        private Dictionary<string, List<string>> ListToDictionary(ArrayList allWords)
        {
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            foreach (string word in allWords)
            {
                String sortedWord = SortLetters(word);
                if(words.ContainsKey(sortedWord))
                {
                    List<string> wordsList = words[sortedWord];
                    if(!wordsList.Contains(word))
                        wordsList.Add(word);
                } else
                {
                    List<string> wordsList = new List<string>();
                    wordsList.Add(word);
                    words.Add(sortedWord, wordsList);
                }
            }

             return words; 
        }

        public List<string> FindFewWords(ArrayList allWords, ArrayList toFind)
        {

            //int noOfLetters = 3;

            String combinedWord = "";

            foreach (String word in toFind)
            {
                combinedWord += word;
            }

            combinedWord = SortLetters(combinedWord);

            return null;
        }

        private Dictionary<string, List<string>> ListToSumDictionary(ArrayList allWords)
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

            return null; ;
        }

    }
}
