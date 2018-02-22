using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApartmentThread
{
    class Apartment
    {
        private String _threadName;

        private int area;
        public int Area
        {
            get
            {
                return area;
            }
            set
            {
                if(Thread.CurrentThread.Name == _threadName)
                {
                    area = value;
                }
            }
        }

        public Apartment()
        {
            _threadName = Thread.CurrentThread.Name;
        }
    }
}
