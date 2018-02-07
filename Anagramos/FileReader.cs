using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagramos
{
    class FileReader : IWordRepository
    {
        private String FilePath = @"C:\Users\justinas.antanaviciu\source\repos\Anagramos\Anagramos\zodynas.txt";

        public ArrayList Words { get; private set; }

        public ArrayList GetData()
        {
            Words = new ArrayList();

            if(File.Exists(FilePath)) {
                string[] allLines = File.ReadAllLines(FilePath);
                foreach (var Line in allLines)
                {
                    string[] lineWords = Line.Split('\t');
                    Words.Add(lineWords[0]);
                    Words.Add(lineWords[2]);
                }
            }
            return Words;
        }
    }
}
