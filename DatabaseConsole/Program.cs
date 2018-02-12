﻿using Implementation.AnagramSolver;
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
            string path = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            IWordRepository reader = new FileReader(path);
            Database db = new Database();
            try
            {
                Console.WriteLine("Reading data from file...");
                List<string> words = reader.GetData();
                Console.WriteLine("Importing data to database...");
                db.AddWordsToDatabase(words);
                Console.WriteLine("Data imported to database");
            } catch
            {
                Console.WriteLine("Error");
            }


        }
    }
}
