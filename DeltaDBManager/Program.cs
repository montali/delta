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
            Console.WriteLine("██████╗ ███████╗██╗  ████████╗ █████╗ \n██╔══██╗██╔════╝██║  ╚══██╔══╝██╔══██╗\n██║  ██║█████╗  ██║     ██║   ███████║\n██║  ██║██╔══╝  ██║     ██║   ██╔══██║\n██████╔╝███████╗███████╗██║   ██║  ██║\n╚═════╝ ╚══════╝╚══════╝╚═╝   ╚═╝  ╚═╝");
            Console.WriteLine("Welcome. I'm doing my thing. Give me a while.");
            try
            {
                ServiceHost svcHost = new ServiceHost(typeof(DBManager));
                svcHost.Open();
                Console.WriteLine("\nDelta is now up and running. Press RETURN to kill it gracefully.");
                Console.ReadLine();
                svcHost.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("I had a problem turning the service on. Tell those bad programmers i had this problem: {0}", e.ToString());
            }
            Console.WriteLine("Delta is now stopped. Press RETURN to kill me. ");
            Console.ReadLine();
        }
    }
}
