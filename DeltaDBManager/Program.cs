using Delta.DeltaDBManager.CarNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Delta.DeltaDBManager
{
    class Program
    {
        public static void Main()
        {
            ServiceHost svcHost = new ServiceHost(typeof(DBManager));
            svcHost.Open();
            Console.WriteLine("This sh*t is LIT!");
            Console.ReadLine();
            svcHost.Close();
            Console.WriteLine("This sh*t ain't lit no more:(");
        }
    }
}
