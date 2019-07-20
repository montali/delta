using System;
using System.Data.Linq.Mapping;
using Delta.DeltaManager.CarNS;
using Delta.DeltaManager.UserNS;

namespace Delta.DeltaDBManager.BookingNS
{
    [Table(Name = "Booking")]
    public class BookingTable
    {
        [Column(IsPrimaryKey = true, Name = "ID")]
        public int ID
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Car")]
        public string BookedCar
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "User")]
        public string Booker
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Start")]
        public DateTime Start
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "End")]
        public DateTime End
        {get;set;}
        public bool Returned
        { get; set; }

        public BookingTable(int ID,string BookedCar, string Booker, DateTime Start, DateTime End)
        {
            this.ID = ID;
            this.BookedCar = BookedCar;
            this.Booker = Booker;
            this.Start = Start;
            this.End = End;
        }
        // Costruttore di "copia" per creare un oggetto table senza sottooggetti
        public BookingTable (Booking booking)
        {
            this.ID = booking.ID;
            this.BookedCar = booking.BookedCar.PlateNumber;
            this.Booker = booking.Booker.Email;
            this.Start = booking.Start;
            this.End = booking.End;
        }
        public BookingTable ()
        {
            this.ID = -1;
            this.BookedCar = null;
            this.Booker = null;
            this.Start = new DateTime(1990,1,1);
            this.End =  new DateTime(1990,1,1);
        }

    }
}
