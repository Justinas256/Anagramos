﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsole
{
    public class Display : IDisplay
    {

        public Action<string> PrintText { private set; get; }
        public Func<string, string> FormatText { private set; get; }

        public Display(Action<string> printAction)
        {
            PrintText = printAction;
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

        /*

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
        */

    }
}
