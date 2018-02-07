using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.AnagramSolver
{
    public interface IAnagramSolver
    {
        void Init(List<String> words);
        List<string> FindWords(List<String> toFind);
    }
}
