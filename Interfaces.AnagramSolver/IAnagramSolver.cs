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
        List<string> AllWords { get; }
        Dictionary<string, List<string>> DictionaryWords { get; }
        void Init(List<String> words);
        List<string> FindWords(List<String> toFind);
    }
}
