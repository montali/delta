using System;
using System.Data.Linq.Mapping;
using Delta.DeltaDBManager.BookingNS;

namespace Delta.DeltaDBManager.ReportNS
{
    [Table(Name = "Report")]
    public class ReportTable
    {
        [Column(IsPrimaryKey = true, Name = "ID")]
        public int ID
        {get;set;}
        [Column(IsPrimaryKey = false, Name = "Booking")]
        public int ReportedBooking
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Type")]
        public string Subject
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "Message")]
        public string Message
        { get; set; }
        public ReportTable(int ID, int ReportedBooking, string Subject, string Message)
        {
            this.ID=ID;
            this.ReportedBooking = ReportedBooking;
            this.Subject = Subject;
            this.Message = Message;
        }
        public ReportTable(Report report)
        {
            this.ID=report.ID;
            this.ReportedBooking = report.ReportedBooking.ID;
            this.Subject = report.Subject;
            this.Message = report.Message;
        }
        public ReportTable()
        {
            this.ID = -1;
            this.ReportedBooking = -1;
            this.Subject = "";
            this.Message = "";
        }
    }
}