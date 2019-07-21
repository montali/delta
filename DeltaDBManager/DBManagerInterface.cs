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



namespace Delta.DeltaDBManager
{
    [ServiceContract]
    public interface DBManagerInterface
    {

        [OperationContract]
        bool BookCar(Booking booking);
        [OperationContract]
        bool DeleteBooking(Booking booking);
        [OperationContract]
        bool UpdateBooking(Booking NewBooking);
        [OperationContract]
        Booking GetBookingByID(int ID);
        [OperationContract]
        bool AddCar(Car car);
        Car GetCarByPlate(string Plate);
        [OperationContract]
        bool DeleteCar(Car car);
        [OperationContract]
        List<Car> GetCars();
        [OperationContract]
        bool UpdateCar(Car updatableCar);
        [OperationContract]
        List<Car> GetAvailableCars(DateTime Start, DateTime End);
        [OperationContract]
        bool AddReport(Report report);
        [OperationContract]
        bool DeleteReport(Report report);
        [OperationContract]
        Report GetReportByID(int ID);
        [OperationContract]
        List<Report> GetReportsForCar(Car car);
        [OperationContract]
        User GetUserByEmail(string Email);
        [OperationContract]
        bool AddUser(User user);
        [OperationContract]
        bool DeleteUser(User user);
    }
}
