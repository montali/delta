using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Delta.DeltaDBManager.BookingNS;
using Delta.DeltaDBManager.CarNS;
using Delta.DeltaDBManager.ReportNS;
using Delta.DeltaDBManager.UserNS;
using System.ServiceModel;
using Delta.DeltaDBManager.ServiceNS;

namespace Delta.DeltaDBManager
{
    [ServiceContract(Namespace = "Delta.DeltaDBManager")]
    public interface DBManagerInterface
    {

        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool BookCar(Booking booking);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool DeleteBooking(Booking booking);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool UpdateBooking(Booking NewBooking);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        Booking GetBookingByID(int ID);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool AddCar(Car car);
        Car GetCarByPlate(string Plate);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool DeleteCar(Car car);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<Car> GetCars();
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool UpdateCar(Car updatableCar);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<Car> GetAvailableCars(DateTime Start, DateTime End);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool AddReport(Report report);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool DeleteReport(Report report);
        [OperationContract]
        Report GetReportByID(int ID);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<Report> GetReportsForCar(Car car);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        User GetUserByEmail(string Email);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool AddUser(User user);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool DeleteUser(User user);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<User> GetUsers();
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool AddService(Service service);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool DeleteService(Service service);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool UpdateService(Service service);

    }
}
