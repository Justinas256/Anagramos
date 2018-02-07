using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.AnagramSolver
{
    public interface IGraphic
    {
        void Start();
        String GetWords();
        void WriteWords(List<string> findedWords);
    }
}
