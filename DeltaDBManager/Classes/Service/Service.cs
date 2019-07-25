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
        public Service (Car ServicedCar, int Kilometers, float TotalSpent)
        {
            this.ServicedCar = ServicedCar;
            this.Kilometers = Kilometers;
            this.TotalSpent = TotalSpent;
        }
    }
}
