using System;
using Delta.DeltaManager.BookingNS;

namespace Delta.DeltaDBManager.ReportNS
{
    public class Report
    {
        public int ID
            {get;set;}
        public Booking ReportedBooking
        { get; set; }
        public string Subject
        { get; set; }
        public string Message
        { get; set; }
        public Report(int ID, Booking ReportedBooking, string Subject, string Message)
        {
            this.ID=ID;
            this.ReportedBooking = ReportedBooking;
            this.Subject = Subject;
            this.Message = Message;
        }
    }
}