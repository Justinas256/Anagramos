using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    [TestFixture]
    class EnumMappingTests
    {
        [Test]
        public void MapIntToGender_1_Male()
        {
            EnumMapping enumMap = new EnumMapping();
            Assert.AreEqual(enumMap.MapIntToGender(1), EnumMapping.Gender.Male);
        }

        [Test]
        public void MapStringToGender_MaleString_MaleEnum()
        {
            EnumMapping enumMap = new EnumMapping();
            Assert.AreEqual(enumMap.MapStringToGender("Male"), EnumMapping.Gender.Male);
        }

        [Test]
        public void MapStringToWeekday_Mondaytring_MondayEnum()
        {
            EnumMapping enumMap = new EnumMapping();
            Assert.AreEqual(enumMap.MapStringToWeekday("Monday"), EnumMapping.Weekday.Monday);
        }

        [Test]
        public void MapValueToEnum_1_Male()
        {
            EnumMapping enumMap = new EnumMapping();
            Assert.AreEqual(enumMap.MapValueToEnum<EnumMapping.Gender, int>(1), EnumMapping.Gender.Male);
        }

        [Test]
        public void MapValueToEnum_MaleString_MaleEnum()
        {
            EnumMapping enumMap = new EnumMapping();
            Assert.AreEqual(enumMap.MapValueToEnum<EnumMapping.Gender, string>("Male"), EnumMapping.Gender.Male);
        }

        [Test]
        public void MapValueToEnum_Mondaytring_MondayEnum()
        {
            EnumMapping enumMap = new EnumMapping();
            Assert.AreEqual(enumMap.MapValueToEnum<EnumMapping.Weekday, string>("Monday"), EnumMapping.Weekday.Monday);
        }
    }
}
