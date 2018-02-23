using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilesManager
{
    class FilesMover
    {
        public void CopyFiles(string sourcePath, string targetPath)
        {
            string fileName, destFile;

            try
            {
                if (System.IO.Directory.Exists(sourcePath))
                {
                    if (!System.IO.Directory.Exists(targetPath))
                    {
                        System.IO.Directory.CreateDirectory(targetPath);
                    }

                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    throw new Exception("Such folder does not exist");
                }
            }
            catch
            {
                throw new Exception("Files were not copied!");
            }  
        }

        public void CopyFilesParallel(string sourcePath, string targetPath)
        {
            if (System.IO.Directory.Exists(sourcePath))
            {
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                string[] files = System.IO.Directory.GetFiles(sourcePath, "*.*");

                Parallel.ForEach(files, newPath =>
                {
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath));
                });
            }
        }

    }
}
