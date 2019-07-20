using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.DeltaManager.CarNS;

namespace Delta.DeltaManager.ServiceNS
{
    class Service
    {
        public Car ServicedCar
        { get; set; }
        public int Kilometers
        { get; set; }
        
        public float TotalSpent
        { get; set; }
        public Service (Car ServicedCar, int Kilometers, float TotalSpent)
        {
            this.ServicedCar = ServicedCar;
            this.Kilometers = Kilometers;
            this.TotalSpent = TotalSpent;
        }
    }
}
