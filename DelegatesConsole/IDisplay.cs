using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsole
{
    //public delegate void PrintText(string input);
    //public delegate string FormatText(string input);

    public interface IDisplay
    {
        Action<string> PrintText { get; }
        Func<string, string> FormatText { get; }

        void Print(string input);
        //void FormattedPrint(FormatText del, string input);
        void FormattedPrint(Func<string,string> del, string input);
    }
}
