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
        List<Booking> GetBookings();
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<Booking> GetBookingsForCar(Car car);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<Booking> GetBookingsForUser(string UserEmail);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool AddCar(Car car);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
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
        bool DeleteReport(int ID);
        [OperationContract]
        Report GetReportByID(int ID);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool UpdateReport(Report UpdatableReport);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<Report> GetReportsForBooking(int BookingID);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<Report> GetReportsForCar(string CarPlate);
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
        bool UpdateUser(User updatableUser);

        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<User> GetUsers();
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        Service GetServiceByID(int ID);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool AddService(Service service);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool DeleteService(int ID);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        bool UpdateService(Service service);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        List<Service> GetServicesForCar(string PlateNumber);
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        int GetMaxBooking();
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        int GetMaxReport();
        [OperationContract]
        [FaultContract(typeof(DatabaseFault))]
        int GetMaxService();


    }
}
