using System;
using System.Runtime.Serialization;

namespace Delta.DeltaDBManager.CarNS
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public string PlateNumber
        { get; set; }
        [DataMember]
        public string Make
        { get; set; }
        [DataMember]
        public string Model
        { get; set; }
        [DataMember]
        public int Year
        { get; set; }
        [DataMember]
        public int Kilometers
        { get; set; }
        [DataMember]
        public int BurnedLiters
        { get; set; }
        public Car(string PlateNumber, string Make, string Model, int Year, int Kilometers)
        {
            this.PlateNumber = PlateNumber;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Kilometers = Kilometers;
        }
    }
}
