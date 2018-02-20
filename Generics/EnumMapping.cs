using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class EnumMapping
    {
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

        public Gender MapIntToGender(int value)
        {
            Gender result;
            if (!Enum.TryParse(value.ToString(), out result))
            {
                throw new Exception($"Value '{value}' is not part of Gender enum");
            }

            return result;
        }

        public Gender MapStringToGender(string value)
        {
            Gender result;
            if (!Enum.TryParse(value, out result))
            {
                throw new Exception($"Value '{value}' is not part of Gender enum");
            }

            return result;
        }

        public Weekday MapStringToWeekday(string value)
        {
            Weekday result;
            if (!Enum.TryParse(value, out result))
            {
                throw new Exception($"Value '{value}' is not part of Weekday enum");
            }

            return result;
        }

        public TEnum MapValueToEnum<TEnum, TValue>(TValue value) where TEnum : struct
                                                                 where TValue : IComparable, IConvertible, IEquatable<TValue>
        {
            if (!Enum.TryParse(value.ToString(), out TEnum result))
            {
                throw new Exception($"Value '{value}' is not part of enum");
            }

            return result;
        }
    }
}
