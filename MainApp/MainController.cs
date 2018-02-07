using Interfaces.AnagramSolver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MainApp
{
    class MainController
    {

        IGraphic Graphic;
        IWordRepository DataReader;
        IAnagramSolver Solver;

        public MainController (IGraphic graphic, IWordRepository dataReader, IAnagramSolver solver)
        {
            Graphic = graphic;
            DataReader = dataReader;
            Solver = solver;
        }

        public void Start()
        {
            ArrayList words = DataReader.GetData();
            String writtenWord = Graphic.GetWords();
            string[] splittedWords = writtenWord.Split(' ', '\t');

            ArrayList toFind = new ArrayList();
            foreach(String word in splittedWords)
            {
                String lowerCaseWord = word.ToLower();
                toFind.Add(lowerCaseWord);
            }

            List<string> findedWords = null;
            if (toFind.Count > 0)
                findedWords = Solver.FindWords(words, toFind);

            Graphic.WriteWords(findedWords);
        }


    }
}
