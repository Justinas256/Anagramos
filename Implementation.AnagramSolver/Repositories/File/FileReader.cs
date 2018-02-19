using Interfaces.AnagramSolver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public class FileReader : IWordRepository
    {
        private String _FilePath;

        public List<string> Words;

        public FileReader(String path)
        {
            _FilePath = path;
        }

        public List<string> GetData()
        {
            Words = new List<string>();

            if(_FilePath != null && File.Exists(_FilePath)) {
                string[] allLines = File.ReadAllLines(_FilePath);
                foreach (var Line in allLines)
                {
                    string[] lineWords = Line.Split('\t');
                    Words.Add(lineWords[0]);
                    Words.Add(lineWords[2]);
                }
            } else
            {
                //Console.WriteLine(Directory.GetCurrentDirectory());
                throw new FileNotFoundException("File was not found!");
            }
            return Words.Distinct().ToList();
        }

        public List<string> GetFilteredWords(string fragment)
        {
            throw new NotImplementedException();
        }

        public void AddNewWord(string word)
        {
            throw new NotImplementedException();
        }

        public void UpdateWord(int wordID, string newWord)
        {
            throw new NotImplementedException();
        }

        public void DeleteWord(int wordID)
        {
            throw new NotImplementedException();
        }

        public string FindWordByID(int wordID)
        {
            throw new NotImplementedException();
        }

        public int FindWordID(string word)
        {
            throw new NotImplementedException();
        }
    }
}
