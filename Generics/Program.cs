using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    //just started

    class Program
    {
        static void Main(string[] args)
        {
            EnumMapping EnumMap = new EnumMapping();

            int week = (int)EnumMap.MapValueToEnum<EnumMapping.Weekday, string>("Friday");
            Console.WriteLine(EnumMap.MapValueToEnum<EnumMapping.Weekday, string>("Friday"));
            Console.WriteLine(week);
            Console.WriteLine(EnumMap.MapValueToEnum<EnumMapping.Gender, string>("Male"));
            Console.WriteLine(EnumMap.MapValueToEnum<EnumMapping.Gender, int>(2));
            Console.ReadLine();
        }

    }
}
