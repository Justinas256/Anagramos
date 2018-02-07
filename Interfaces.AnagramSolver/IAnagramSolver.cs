﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.AnagramSolver
{
    public interface IAnagramSolver
    {
        List<string> FindWords(ArrayList allWords, ArrayList toFind);
    }
}