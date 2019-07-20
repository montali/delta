using Delta.DeltaDBManager.BookingNS;
using Delta.DeltaDBManager.CarNS;
using Delta.DeltaDBManager.ReportNS;
using Delta.DeltaDBManager.ServiceNS;
using Delta.DeltaDBManager.UserNS;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Delta.DeltaDBManager
{
    public partial class DeltaDB : DataContext
    {
        public Table<BookingTable> Bookings;
        public Table<CarTable> Cars;
        public Table<ReportTable> Reports;
        public Table<ServiceTable> Services;
        public Table<UserTable> Users;
        public DeltaDB(string connection) : base(connection) { }
    }
}
