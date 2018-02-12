﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.AnagramSolver
{
    public interface IWordRepository
    {
        List<string> GetData();
        List<string> GetFilteredWords(string fragment);
    }
}
