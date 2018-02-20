using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsole
{
    public class Display : IDisplay
    {
        private PrintText _printText;
        private FormatText _formatText;

        public Display(PrintText printDelegate)
        {
            _printText = new PrintText(printDelegate);
        }

        public void Print(string input)
        {
            _printText(input);
        }
        public void FormattedPrint(FormatText del, string input)
        {
            _formatText = new FormatText(del);
            input = _formatText(input);
            _printText(input);
        }
    }
}
