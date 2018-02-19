using Implementation.AnagramSolver;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppConfig.FilePath;
            IWordRepository reader = new FileReader(path);
            //IDatabase db = new DatabaseSQL();
            IDatabase db = new DatabaseEFCF();
            try
            {
                Console.WriteLine("Deleting tables");
                db.DeleteTable("UserLogs");
                db.DeleteTable("CachedAnagrams");
                db.DeleteTable("CachedWords");
                db.DeleteTable("Words");
                Console.WriteLine("Tables deleted");
                Console.WriteLine("Reading data from file...");
                List<string> words = reader.GetData();
                Console.WriteLine("Importing data to database...");
                db.AddWordsToDatabase(words);
                Console.WriteLine("Data imported to database");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}
