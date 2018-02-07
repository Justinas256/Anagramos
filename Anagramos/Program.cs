using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagramos
{
    class Program
    {
        static void Main(string[] args)
        {

            MainController controller = new MainController(new OneWordsConsole(), new FileReader(), new OneWordFinder());
            controller.Start();

        }
    }
}
