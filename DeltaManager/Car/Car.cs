using System;

namespace Delta.DeltaManager.CarNS
{
    public class Car
    {
        public string PlateNumber
        { get; set; }
        public string Make
        { get; set; }
        public string Model
        { get; set; }
        public int Year
        { get; set; }
        public int Kilometers
        { get; set; }
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
