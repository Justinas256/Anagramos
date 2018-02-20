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
        static void Main(string[] args)
        {
            PrintText printDel = new PrintText(PrintToConsole);
            FormatText formatDel = new FormatText(FirstLetterUppercase);

            IDisplay display = new Display(printDel);
            display.FormattedPrint(formatDel, "hello");
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
