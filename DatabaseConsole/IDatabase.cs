using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    public interface IDatabase
    {
        void AddWordsToDatabase(List<string> words);
        void DeleteTable(string table);
    }
}
