using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Delta.DeltaDBManager.BookingNS;
using Delta.DeltaDBManager.CarNS;
using Delta.DeltaDBManager.ReportNS;
using Delta.DeltaDBManager.ServiceNS;
using Delta.DeltaDBManager.UserNS;


namespace Delta.DeltaDBManager
{
    class DBManager : DBManagerInterface
    {
        private DeltaDB Connection;
        public DBManager()
        {
            Connection = new DeltaDB("Server=localhost\\SQLEXPRESS;Database=Delta;Trusted_Connection=True;");
        }


        public bool BookCar(Booking booking)
        {
            try
            {
                this.Connection.Bookings.InsertOnSubmit(new BookingTable(booking));
                this.Connection.SubmitChanges();
                return true;
            }catch(Exception e)
            {
                throw new FaultException<DatabaseFault>(new DatabaseFault(e.ToString()));
            }
        }
        public bool DeleteBooking (Booking DeletingBooking)
        {
            try
            {
                var query =
                    (from booking in this.Connection.Bookings
                     where booking.ID == DeletingBooking.ID
                     select booking)
                    .First();
                this.Connection.Bookings.DeleteOnSubmit(query);
                this.Connection.SubmitChanges();
                return true;
            }catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateBooking (Booking NewBooking)
        {
            try
            {
                var UpdatingBooking =
                (from OldBooking in this.Connection.Bookings
                 where OldBooking.ID == NewBooking.ID
                 select OldBooking)
                 .First();
                UpdatingBooking.BookedCar = NewBooking.BookedCar.PlateNumber;
                UpdatingBooking.Booker = NewBooking.Booker.Email;
                UpdatingBooking.Start= NewBooking.Start;
                UpdatingBooking.End = NewBooking.End;
                this.Connection.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public Booking GetBookingByID (int ID)
        {
            try
            {
                var query =
                (from booking in this.Connection.Bookings
                 where booking.ID== ID
                 select booking)
                .First();
                return new Booking(query.ID, this.GetCarByPlate(query.BookedCar), this.GetUserByEmail(query.Booker),query.Start,query.End);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<Booking> GetBookings()
        {
            List<Booking> Bookings = new List<Booking>();
            var query =
                from bookings in this.Connection.Bookings
                select bookings;

            foreach (var booked in query)
            {
                Bookings.Add(new Booking(booked.ID, this.GetCarByPlate(booked.BookedCar), this.GetUserByEmail(booked.Booker), booked.Start, booked.End));
            }
            return Bookings;
        }

        public List<Booking> GetBookingsForCar(Car car)
        {
            List<Booking> Bookings = new List<Booking>();
            var query =
                from bookings in this.Connection.Bookings
                where bookings.BookedCar == car.PlateNumber
                select bookings;

            foreach (var booked in query)
            {
                Bookings.Add(new Booking(booked.ID, car, this.GetUserByEmail(booked.Booker), booked.Start, booked.End));
            }
            return Bookings;
        }

        public List<Booking> GetBookingsForUser(string UserEmail)
        {
            List<Booking> Bookings = new List<Booking>();
            var query =
                from bookings in this.Connection.Bookings
                where bookings.Booker == UserEmail
                select bookings;

            foreach (var booked in query)
            {
                Bookings.Add(new Booking(booked.ID, this.GetCarByPlate(booked.BookedCar), this.GetUserByEmail(booked.Booker), booked.Start, booked.End));
            }
            return Bookings;
        }

        public bool AddCar(Car car)
        {
            try
            {
                this.Connection.Cars.InsertOnSubmit(new CarTable(car));
                this.Connection.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Car GetCarByPlate (string Plate)
        {
            try
            {
                var query =
                (from car in this.Connection.Cars
                 where car.PlateNumber == Plate
                 select car)
                .First();
                return new Car(query.PlateNumber, query.Make, query.Model, query.Year, query.Kilometers, query.BurnedLiters);
            } catch (Exception e)
            {
                return null;
            }
        }

        public bool DeleteCar(Car DeletingCar)
        {
            try
            {
                var query =
                    (from car in this.Connection.Cars
                     where car.PlateNumber == DeletingCar.PlateNumber
                     select car)
                    .First();
                this.Connection.Cars.DeleteOnSubmit(query);
                this.Connection.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Car> GetCars()
        {
            List<Car> Cars = new List<Car>();
            var query =
                from car in this.Connection.Cars
                select car;
            foreach (var Automobile in query)
            {
                Cars.Add(new Car(Automobile.PlateNumber,Automobile.Make,Automobile.Model,Automobile.Year,Automobile.Kilometers, Automobile.BurnedLiters));
            }
            return Cars;
        }

        public bool UpdateCar(Car updatableCar)
        {
                var updatingCar =
                (from car in this.Connection.Cars
                 where car.PlateNumber == updatableCar.PlateNumber
                 select car)
                 .First();
                updatingCar.Make = updatableCar.Make;
                updatingCar.Model = updatableCar.Model;
                updatingCar.Year = updatableCar.Year;
                updatingCar.Kilometers = updatableCar.Kilometers;
                updatingCar.BurnedLiters = updatableCar.BurnedLiters;
                this.Connection.SubmitChanges();
                return true;
            
        }

        public List<Car> GetAvailableCars (DateTime Start, DateTime End)
        {
            List<Car> Cars = new List<Car>();
            var bookings =
                from booking in this.Connection.Bookings
                where (Start > booking.Start && End > booking.End) || (Start > booking.Start && Start < booking.End)
                select booking.BookedCar;

            var query =
                from cars in this.Connection.Cars
                .Where(i => !bookings.Contains(i.PlateNumber))
                select cars;
            foreach (var Automobile in query)
            {
                Cars.Add(new Car(Automobile.PlateNumber, Automobile.Make, Automobile.Model, Automobile.Year, Automobile.Kilometers, Automobile.BurnedLiters));
            }
            return Cars;
        }
        public bool AddReport (Report report)
        {
            
                this.Connection.Reports.InsertOnSubmit(new ReportTable(report));
                this.Connection.SubmitChanges();
                return true;
            

        }
        public bool DeleteReport (int ID)
        {
            try
            {
                var query =
                    (from report in this.Connection.Reports
                     where report.ID == ID
                     select report)
                    .First();
                this.Connection.Reports.DeleteOnSubmit(query);
                this.Connection.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Report GetReportByID (int ID)
        {
            try
            {
                var query =
                    (from report in this.Connection.Reports
                     where report.ID == ID
                     select report)
                    .First();
                return new Report(query.ID, this.GetBookingByID(query.ReportedBooking), query.Subject, query.Message);
            } catch (Exception e)
            {
                return null;
            }
        }

        public List<Report> GetReportsForCar(string CarPlate)
        {
            List<Report> Reports = new List<Report>();
            var query =
                from report in this.Connection.Reports
                where ((this.GetBookingByID(report.ReportedBooking).BookedCar.PlateNumber) == CarPlate)
                select report;
            foreach (var SingleReport in query)
            {
                Reports.Add(new Report(SingleReport.ID, this.GetBookingByID(SingleReport.ReportedBooking
                    ), SingleReport.Subject, SingleReport.Message));
            }
            return Reports;
            

        }
        public bool UpdateReport (Report UpdatableReport)
        {
            var updatingReport =
                (from reportQuery in this.Connection.Reports
                 where reportQuery.ID == UpdatableReport.ID
                 select reportQuery)
                 .First();
            updatingReport.Subject = UpdatableReport.Subject;
            updatingReport.Message = UpdatableReport.Message;
            updatingReport.ReportedBooking = UpdatableReport.ReportedBooking.ID;
            this.Connection.SubmitChanges();
            return true;
        }
        public List<Report> GetReportsForBooking(int BookingID)
        {
            List<Report> Reports = new List<Report>();
                var query =
                    from report in this.Connection.Reports
                    where (report.ReportedBooking == BookingID)
                    select report;
                foreach (var SingleReport in query)
                {
                    Reports.Add(new Report(SingleReport.ID, this.GetBookingByID(SingleReport.ReportedBooking
                        ), SingleReport.Subject, SingleReport.Message));
                }
                return Reports;
           

        }
        public User GetUserByEmail (string Email)
        {
            try
            {
                var query =
                    (from user in this.Connection.Users
                    where user.Email == Email
                    select user)
                    .First();
                return new User(query.Name, query.Email, query.PasswordHash,Convert.ToBoolean(query.isAdmin),Convert.ToInt16(query.LicensePoints), query.LicenseExpiration, query.License);
            } catch (Exception e)
            {
                return null;
            }
        }

        public bool AddUser (User user)
        {
                this.Connection.Users.InsertOnSubmit(new UserTable(user));
                this.Connection.SubmitChanges();
                return true;
        }

        public bool DeleteUser (User DeletingUser)
        {
            var query =
                (from user in this.Connection.Users
                 where user.Email == DeletingUser.Email
                 select user)
                .First();
            this.Connection.Users.DeleteOnSubmit(query);
            this.Connection.SubmitChanges();
                return true;
        }
        public bool UpdateUser (User updatableUser)
        {
                var updatingUser =
                    (from userQuery in this.Connection.Users
                     where userQuery.Email == updatableUser.Email
                     select userQuery)
                     .First();
                updatingUser.Name= updatableUser.Name;
                updatingUser.License = updatableUser.License;
                updatingUser.LicenseExpiration = updatableUser.LicenseExpiration;
                updatingUser.LicensePoints = updatableUser.LicensePoints;
                updatingUser.PasswordHash = updatableUser.PasswordHash;
                updatingUser.isAdmin = Convert.ToInt32(updatableUser.isAdmin);
                this.Connection.SubmitChanges();
                return true;
            

        }
        public List<User> GetUsers()
        {

            List<User> Users = new List<User>();
            var query =
                from userz in this.Connection.Users
                select userz;
            
            foreach (var utonto in query)
            {
                Users.Add(new User(utonto.Name, utonto.Email, utonto.PasswordHash,Convert.ToBoolean(utonto.isAdmin),Convert.ToInt16(utonto.LicensePoints), utonto.LicenseExpiration, utonto.License));
            }
            return Users;


        }
        public bool AddService(Service service)
        {

                this.Connection.Services.InsertOnSubmit(new ServiceTable(service));
                this.Connection.SubmitChanges();
                return true;
            

        }
        public bool DeleteService(int ID)
        {
            try
            {
                var service =
                   (from serv in this.Connection.Services
                    where serv.ID == ID
                    select serv)
                    .First();
                this.Connection.Services.DeleteOnSubmit(service);
                this.Connection.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool UpdateService(Service UpdatableService)
        {
            var updatingService =
                (from serv in this.Connection.Services
                 where serv.ID== UpdatableService.ID
                 select serv)
                 .First();
            updatingService.Kilometers = UpdatableService.Kilometers;
            updatingService.ServicedCar = UpdatableService.ServicedCar.PlateNumber;
            updatingService.TotalSpent = UpdatableService.TotalSpent;
            this.Connection.SubmitChanges();
            return true;
        
    }
        public List<Service> GetServicesForCar (string PlateNumber)
        {
                List < Service > RetrievedServices= new List<Service>();
                var query =
                    from serv in this.Connection.Services
                    where serv.ServicedCar == PlateNumber
                    select serv;
                foreach (var service in query)
                {
                    RetrievedServices.Add(new Service(service.ID, this.GetCarByPlate(service.ServicedCar), service.Kilometers, (float)service.TotalSpent));
                }
                return RetrievedServices;
            
        }
        public Service GetServiceByID (int ID)
        {
            var service =
               (from serv in this.Connection.Services
                where serv.ID == ID
                select serv)
                .First();
            return new Service(service.ID, this.GetCarByPlate(service.ServicedCar), service.Kilometers, (float)service.TotalSpent);
        }
        public int GetMaxBooking()
        {
            try
            {
                var query =
                    (from book in this.Connection.Bookings
                    select book.ID)
                    .Max();
                return query;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public int GetMaxService()
        {
            try
            {
                var query =
                    (from serv in this.Connection.Services
                     select serv.ID)
                    .Max();
                return query;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public int GetMaxReport()
        {
            try
            {
                var query =
                    (from repo in this.Connection.Reports
                     select repo.ID)
                    .Max();
                return query;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
