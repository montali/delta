using System;
using System.Runtime.Serialization;
using Delta.DeltaDBManager.BookingNS;

namespace Delta.DeltaDBManager.ReportNS
{
    [DataContract]
    public class Report
    {
        [DataMember]
        public int ID
            {get;set;}
        [DataMember]
        public Booking ReportedBooking
        { get; set; }
        [DataMember]
        public string Subject
        { get; set; }
        [DataMember]
        public string Message
        { get; set; }
        public Report(int ID, Booking ReportedBooking, string Subject, string Message)
        {
            this.ID=ID;
            this.ReportedBooking = ReportedBooking;
            this.Subject = Subject;
            this.Message = Message;
        }
        public Report()
        {
            this.ID = -1;
            this.ReportedBooking = null;
            this.Subject = "";
            this.Message = "";
        }
    }
}