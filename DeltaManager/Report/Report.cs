using System;

namespace Delta.DeltaManager.ReportNS
{
    public class Report
    {
        public Booking ReportedBooking
        { get; set; }
        public string Subject
        { get; set; }
        public string Message
        { get; set; }
        public Report(Booking ReportedBooking, string Subject, string Message)
        {
            this.ReportedBooking = ReportedBooking;
            this.Subject = Subject;
            this.Message = Message;
        }
    }
}