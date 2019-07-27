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
        public Car(string PlateNumber, string Make, string Model, int Year, int Kilometers, int BurnedLiters)
        {
            this.PlateNumber = PlateNumber;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Kilometers = Kilometers;
            this.BurnedLiters = BurnedLiters;
        }
        public Car (Car car)
        {
            this.PlateNumber = car.PlateNumber;
            this.Make = car.Make;
            this.Model = car.Model;
            this.Year = car.Year;
            this.Kilometers = car.Kilometers;
            this.BurnedLiters = car.BurnedLiters;
        }
    }
}
