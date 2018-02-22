using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentThread
{
    class Program
    {
        static void Main(string[] args)
        {

            Apartment apartment = new Apartment();

            Thread firstThread = new Thread(() =>
            {
                apartment = new Apartment();
                apartment.Area = 20;
            });
            firstThread.Name = "FirstThread";

            Thread secondThread = new Thread(() =>
            {
                apartment.Area = 100;
            });

            firstThread.Start();
            firstThread.Join();
            secondThread.Start();
            secondThread.Join();

            Console.WriteLine(apartment.Area);
            Console.ReadLine();

        }
    }
}
