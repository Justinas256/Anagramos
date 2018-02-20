using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsole
{
    public class DisplayWithEvents : IDisplay
    {
        public Action<string> PrintText { private set; get; }
        public Func<string, string> FormatText { private set; get; }

        public DisplayWithEvents(Action<string> printAction)
        {
            PrintText = printAction;
            Program.OnPrintText += PrintText;
        }

        public void Print(string input)
        {
            PrintText(input);
        }
        public void FormattedPrint(Func<string, string> del, string input)
        {
            FormatText = del;
            input = FormatText(input);
            PrintText(input);
        }
    }
}
