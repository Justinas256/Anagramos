using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager
{
    class FilesCreator
    {
        public void CreateFile(string path, string baseFileName, int noOfFiles)
        {
            string fileName, filePath;
            try
            {
                for (int i = 1; i <= noOfFiles; i++)
                {
                    fileName = baseFileName + i.ToString();
                    filePath = path + fileName + ".txt";

                    // Delete the file if it exists.
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    // Create the file.
                    using (FileStream fs = File.Create(filePath))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error -- creating files");
            }
        }
    }
}
