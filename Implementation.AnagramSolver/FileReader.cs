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
        private String FilePath = Path.Combine(Directory.GetCurrentDirectory(), "\\zodnas.txt");

        public ArrayList Words { get; private set; }

        public ArrayList GetData()
        {
            Words = new ArrayList();

            if(File.Exists(FilePath)) {
                Console.WriteLine(Directory.GetCurrentDirectory());
                string[] allLines = File.ReadAllLines(FilePath);
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
            return Words;
        }
    }
}
