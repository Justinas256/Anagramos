using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //FilesCreator filesCreator = new FilesCreator();
            //filesCreator.CreateFile(@"C:\Users\justinas.antanaviciu\Documents\Files\", "file", 50000);

            try
            {
                FilesMover filesMover = new FilesMover();
                filesMover.CopyFiles(@"C:\Users\justinas.antanaviciu\Documents\Files", @"C:\Users\justinas.antanaviciu\Documents\NewFiles");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
