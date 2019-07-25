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
        public float TotalSpent
        { get; set; }
        public ServiceTable (string ServicedCar, int Kilometers, float TotalSpent)
        {
            this.ServicedCar = ServicedCar;
            this.Kilometers = Kilometers;
            this.TotalSpent = TotalSpent;
        }
        public ServiceTable (Service service)
        {
            this.ServicedCar = service.ServicedCar.PlateNumber;
            this.Kilometers = service.Kilometers;
            this.TotalSpent = service.TotalSpent;
        }
    }
}
