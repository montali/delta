using System;
using System.Data.Linq.Mapping;

namespace Delta.DeltaDBManager.CarNS
{
    [Table(Name = "Car")]
    public class CarTable
    {
        [Column(IsPrimaryKey = true, Name = "PlateNo")]
        public string PlateNumber
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Make")]
        public string Make
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Model")]
        public string Model
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Year")]
        public int Year
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Kilometers")]
        public int Kilometers
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Liters")]
        public int BurnedLiters
        { get; set; }
        public CarTable(string PlateNumber, string Make, string Model, int Year, int Kilometers, int BurnedLiters)
        {
            this.PlateNumber = PlateNumber;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Kilometers = Kilometers;
            this.BurnedLiters = BurnedLiters;
        }
        public CarTable(Car car)
        {
            this.PlateNumber = car.PlateNumber;
            this.Make = car.Make;
            this.Model = car.Model;
            this.Year = car.Year;
            this.Kilometers = car.Kilometers;
            this.BurnedLiters = car.BurnedLiters;
        }
        public CarTable(){
        this.PlateNumber=null;
            this.Make=null;
            this.Model=null;
            this.Year=0;
            this.Kilometers=0;
            this.BurnedLiters=0;
            }

        }
}
