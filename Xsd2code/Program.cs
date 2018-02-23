using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsd2code
{
    class Program
    {
        static void Main(string[] args)
        {
            USAddress billTo = new USAddress();
            billTo.city = "New york";
            billTo.country = "USA";
            billTo.name = "John Smith";
            billTo.state = "New York";
            billTo.street = "Street";
            billTo.zip = "091277";

            USAddress[] shipTo = new USAddress[]
            {
                billTo
            };

            PurchaseOrderType purchuase = new PurchaseOrderType();
            purchuase.BillTo = billTo;
            purchuase.OrderDate = DateTime.Now;
            purchuase.OrderDateSpecified = true;
            purchuase.ShipTo = shipTo;

            Console.WriteLine(purchuase.Serialize());
            Console.ReadLine();

    }
    }
}
