using Implementation.AnagramSolver;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
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
                ArrayList words = new ArrayList();
                FileReader fileReader = new FileReader();
                words = fileReader.GetData();
                Assert.NotNull(words);
                if (words != null)
                    Assert.NotZero(words.Count);
        }

        [Test]
        public void GetData_FileExist_Exists()
        {
            FileReader fileReader = new FileReader();
            fileReader.GetData();
        }

    }
}
