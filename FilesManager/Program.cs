using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            string sourcePath = @"C:\Users\justinas.antanaviciu\Documents\Files";
            string targetPath = @"C:\Users\justinas.antanaviciu\Documents\NewFiles";

            try
            {
                Stopwatch sw = new Stopwatch();
                FilesMover filesMover = new FilesMover();

                sw.Start();

                //filesMover.CopyFiles(sourcePath, targetPath);
                filesMover.CopyFilesParallel(sourcePath, targetPath);

                sw.Stop();
                Console.WriteLine("Elapsed={0}", sw.Elapsed);

                Console.WriteLine("Files were coppied!");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
            
        }
    }
}
