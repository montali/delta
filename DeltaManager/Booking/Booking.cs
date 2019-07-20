using System;

namespace Delta.DeltaManager.BookingNS
{
    public class Booking
    {
        public Car bookedCar
        { get; set; }
        public User booker
        { get; set; }
        public DateTime start
        { get; set; }
        public DateTime end
        {get;set;}
        public bool returned
        { get; set; }

        public Booking(Car bookedCar, User booker, DateTime start, DateTime end)
        {
            this.bookedCar = bookedCar;
            this.booker = booker;
            this.start = start;
            this.end = end;
        }

    }
}
