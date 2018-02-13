using Interfaces.AnagramSolver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public class OneWordsConsole : IGraphic
    {
        public void Start()
        {
            Console.WriteLine("Hi!!!");
        }

        public string GetWords()
        {
            Console.WriteLine("Write one word:");
            String writtenWord = Console.ReadLine();
            Console.WriteLine("\nTrying to find word: <<" + writtenWord + ">>\n");
            return writtenWord;


        }

        public void WriteWords(List<string> findedWords)
        {
            if (findedWords != null)
            {
                Console.WriteLine(string.Join(", ", findedWords));
                Console.WriteLine("Words finded!");
            }
            else
            {
                Console.WriteLine("Words not founded!");
            }
            Console.Read();
        }

        public void ErrorMessage(string error)
        {
            Console.WriteLine(error);
            Console.Read();
        }

    }
}
