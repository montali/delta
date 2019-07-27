using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Delta.DeltaDBManager.CarNS;

namespace Delta.DeltaDBManager.ServiceNS
{
    [DataContract]
    public class Service
    {
        [DataMember]
        public int ID
        { get; set; }
        [DataMember]
        public Car ServicedCar
        { get; set; }
        [DataMember]
        public int Kilometers
        { get; set; }
        [DataMember]
        public float TotalSpent
        { get; set; }
        public Service (int ID, Car ServicedCar, int Kilometers, float TotalSpent)
        {
            this.ID = ID;
            this.ServicedCar = ServicedCar;
            this.Kilometers = Kilometers;
            this.TotalSpent = TotalSpent;
        }
        public Service()
        {
            this.ID = -1;
            this.ServicedCar = null;
            this.Kilometers = 0;
            this.TotalSpent = 0;
        }
    }
}
