using Implementation.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string _path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            var fileReader = new FileReader(_path);
            var solver = new OneWordFinder(fileReader.GetData());
            MainController controller = new MainController(new OneWordsConsole(), solver);
            controller.Start();
        }
    }
}
