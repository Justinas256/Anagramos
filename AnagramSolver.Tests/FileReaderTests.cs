using Implementation.AnagramSolver;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.Tests
{
    [TestFixture]
    class FileReaderTests
    {

        [Test]
        public void GetData_RequestData_AtLeastOneWord()
        {
            List<String> words = new List<String>();
            string _path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            FileReader fileReader = new FileReader(_path);
            words = fileReader.GetData();
            Assert.NotNull(words);
            if (words != null)
            {
                Assert.NotZero(words.Count);
            }
        }

        [Test]
        public void GetData_FileExist_Exists()
        {
            string _path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            FileReader fileReader = new FileReader(_path);
            fileReader.GetData();
        }

        [Test]
        public void GetData_FileNotExist_Exception()
        {
            void CheckFunction()
            {
                FileReader fileReader = new FileReader(" ");
                fileReader.GetData();
            }
            Assert.Throws(typeof(FileNotFoundException), CheckFunction);
        }

    }
}
