using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsole
{
    class Program
    {
        public static event Action<string> OnPrintText;

        static void Main(string[] args)
        {
            /*
            -------DELEGATES------------
            PrintText printText = new PrintText(PrintToConsole);
            FormatText formatText = new FormatText(FirstLetterUppercase);
            */

            /*
            -------FUNC--ACTION------------
            Action<string> printText = PrintToConsole;
            Func<string, string> formatText = FirstLetterUppercase;

            --Display text--
            IDisplay display = new Display(printText);
            display.FormattedPrint(formatText, "hello");
             */

            //---EVENTS--
            DisplayWithEvents.TextPrinted += PrintToDebug;
            DisplayWithEvents.TextPrinted += PrintToConsole;
            IDisplay displayEvents = new DisplayWithEvents();
            displayEvents.Print("Hi");

        }

        public static void PrintToConsole(string input)
        {
            Console.WriteLine(input);
            Console.ReadLine();
        }

        public static void PrintToDebug(string input)
        {
            Debug.WriteLine(input);
        }

        public static void PrintToTextFile(string input)
        {
            //print to text file
        }

        public static string FirstLetterUppercase(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
