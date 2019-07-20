using Delta.DeltaDBManager.CarNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.DeltaDBManager
{
    class Program
    {
        public static void Main()
        {
            DBManager daje = new DBManager();
            List<Car> cars = daje.GetAvailableCars(new DateTime(2019, 11, 01), new DateTime(2019, 11, 02));
            
            //List<Car> cars=daje.GetCars();
            foreach (var auto in cars)
            {
                Console.WriteLine("Marca:{0}\tModello:{1}\tTarga:{2}",auto.Make,auto.Model,auto.PlateNumber);
            }
            Console.ReadLine();
        }
    }
}
