using System;
using System.Runtime.Serialization;
using Delta.DeltaDBManager.CarNS;
using Delta.DeltaDBManager.UserNS;

namespace Delta.DeltaDBManager.BookingNS
{
    [DataContract]
    public class Booking
    {
        [DataMember]
        public int ID
        { get; set; }
        [DataMember]
        public Car BookedCar
        { get; set; }
        [DataMember]
        public User Booker
        { get; set; }
        [DataMember]
        public DateTime Start
        { get; set; }
        [DataMember]
        public DateTime End
        {get;set;}
        [DataMember]
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
