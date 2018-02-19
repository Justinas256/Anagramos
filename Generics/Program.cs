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
        }

        public enum Gender : int
        {
            Male = 1,
            Female = 2
        }

        public enum Weekday
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public static Gender MapIntToGender(int value)
        {
            Gender result;
            if (!Enum.TryParse(value.ToString(), out result))
            {
                throw new Exception($"Value '{value}' is not part of Gender enum");
            }

            return result;
        }

        public static Gender MapStringToGender(string value)
        {
            Gender result;
            if (!Enum.TryParse(value, out result))
            {
                throw new Exception($"Value '{value}' is not part of Gender enum");
            }

            return result;
        }

        public static Weekday MapStringToWeekday(string value)
        {
            Weekday result;
            if (!Enum.TryParse(value, out result))
            {
                throw new Exception($"Value '{value}' is not part of Weekday enum");
            }

            return result;
        }

        /*
        public static T MapValueToEnum<T>(string value) where T: struct, IConvertible, IComparable, IFormattable
        {
            
            if (!Enum.TryParse(value, out T result))
            {
                throw new Exception($"Value '{value}' is not part of enum");
            }

            return result;
        }
        */

    }
}
