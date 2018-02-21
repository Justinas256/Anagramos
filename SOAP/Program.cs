using SOAP.SunSetServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP
{
    class Program
    {
        static void Main(string[] args)
        {
            SunSetRiseServiceSoapClient service = new SunSetRiseServiceSoapClient("SunSetRiseServiceSoap");
            LatLonDate dat = new LatLonDate();

            dat.Latitude = 54.687157f;
            dat.Longitude = 25.279652f;
            dat.Year = DateTime.Now.Year;
            dat.Month = DateTime.Now.Month;
            dat.Day = DateTime.Now.Day;
            dat.TimeZone = 3;

            service.GetSunSetRiseTime(dat);
            var SunTime = service.GetSunSetRiseTime(dat);

            Console.WriteLine("Sunrise time: " + SunTime.SunRiseTime);
            Console.WriteLine("Sunset time: " + SunTime.SunSetTime);
            Console.ReadLine();


        }
    }
}
