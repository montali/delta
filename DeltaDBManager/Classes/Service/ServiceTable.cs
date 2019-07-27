using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using Delta.DeltaDBManager.CarNS;

namespace Delta.DeltaDBManager.ServiceNS
{
    [Table(Name = "Service")]
    public class ServiceTable
    {
        [Column(IsPrimaryKey = true, Name = "ID")]
        public int ID
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Car")]
        public string ServicedCar
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Kilometers")]
        public int Kilometers
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "TotalSpent")]
        public double TotalSpent
        { get; set; }
        public ServiceTable (int ID, string ServicedCar, int Kilometers, double TotalSpent)
        {
            this.ID = ID;
            this.ServicedCar = ServicedCar;
            this.Kilometers = Kilometers;
            this.TotalSpent = TotalSpent;
        }
        public ServiceTable (Service service)
        {
            this.ID = service.ID;
            this.ServicedCar = service.ServicedCar.PlateNumber;
            this.Kilometers = service.Kilometers;
            this.TotalSpent = (double)service.TotalSpent;
        }
        public ServiceTable()
        {
            this.ID = -1;
            this.ServicedCar = null;
            this.Kilometers = 0;
            this.TotalSpent = 0;
        }
    }
}
