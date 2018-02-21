using Anagram.Core;
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
        //IWordRepository DataReader;
        IAnagramSolver Solver;

        public MainController (IGraphic graphic, IAnagramSolver solver)
        {
            Graphic = graphic;
            //DataReader = dataReader;
            Solver = solver;
        }

        public void Start()
        {
            try
            {
                String writtenWord = Graphic.GetWords();
                string[] splittedWords = writtenWord.Split(' ', '\t');

                List<String> toFind = splittedWords.Select(x => x.ToLower()).ToList();

                /*
                foreach (String word in splittedWords)
                {
                    String lowerCaseWord = word.ToLower();
                    toFind.Add(lowerCaseWord);
                }
                */

                List<string> findedWords = null;
                if (toFind.Count > 0)
                    findedWords = Solver.FindWords(toFind);

                Graphic.WriteWords(findedWords);
            } catch (Exception e)
            {
                Graphic.ErrorMessage(e.Message);
            }
        }


    }
}
