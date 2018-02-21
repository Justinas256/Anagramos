using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsole
{
    public class DisplayWithEvents : IDisplay
    {
        public static event Action<string> TextPrinted;

        public Action<string> PrintText { private set; get; } //not used
        public Func<string, string> FormatText { private set; get; }

        public void Print(string input)
        {
            OnTextPrinted(input);
        }

        protected virtual void OnTextPrinted(string input)
        {
            TextPrinted?.Invoke(input);
        }

        public void FormattedPrint(Func<string, string> del, string input)
        {
            FormatText = del;
            Print(input);
        }
    }
}
