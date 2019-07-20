using System;
using Delta.DeltaManager.CarNS;
using Delta.DeltaManager.UserNS;

namespace Delta.DeltaDBManager.BookingNS
{
    public class Booking
    {
        public int ID
        { get; set; }
        public Car BookedCar
        { get; set; }
        public User Booker
        { get; set; }
        public DateTime Start
        { get; set; }
        public DateTime End
        {get;set;}
        public bool Returned
        { get; set; }

        public Booking(int ID, Car BookedCar, User Booker, DateTime Start, DateTime End)
        {
            this.ID = ID;
            this.BookedCar = BookedCar;
            this.Booker = Booker;
            this.Start = Start;
            this.End = End;
        }

    }
}
