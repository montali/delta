﻿using System;
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
                return true;
            }catch(Exception e)
            {
                throw new FaultException<DatabaseFault>(new DatabaseFault(e.ToString()));
                return false;
            }
        }
        public bool DeleteBooking (Booking booking)
        {
            try
            {
                this.Connection.Bookings.DeleteOnSubmit(new BookingTable(booking));
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
        public bool AddCar(Car car)
        {
            try
            {
                this.Connection.Cars.InsertOnSubmit(new CarTable(car));
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
                return new Car(query.PlateNumber, query.Make, query.Model, query.Year, query.Kilometers);
            } catch (Exception e)
            {
                return null;
            }
        }

        public bool DeleteCar(Car car)
        {
            try
            {
                this.Connection.Cars.DeleteOnSubmit(new CarTable(car));
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
                Cars.Add(new Car(Automobile.PlateNumber,Automobile.Make,Automobile.Model,Automobile.Year,Automobile.Kilometers));
            }
            return Cars;
        }

        public bool UpdateCar(Car updatableCar)
        {
            try
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
                return true;
            }
            catch ( Exception e)
            {
                return false;
            }
        }

        public List<Car> GetAvailableCars (DateTime Start, DateTime End)
        {
            List<Car> Cars = new List<Car>();
            var bookings =
                from booking in this.Connection.Bookings
                where (Start < booking.Start && End < booking.End) || (Start > booking.Start && Start < booking.End)
                select booking.BookedCar;

            var query =
                from cars in this.Connection.Cars
                .Where(i => !bookings.Contains(i.PlateNumber))
                select cars;
            foreach (var Automobile in query)
            {
                Cars.Add(new Car(Automobile.PlateNumber, Automobile.Make, Automobile.Model, Automobile.Year, Automobile.Kilometers));
            }
            return Cars;
        }
        public bool AddReport (Report report)
        {
            try
            {
                this.Connection.Reports.InsertOnSubmit(new ReportTable(report));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteReport (Report report)
        {
            try
            {
                this.Connection.Reports.DeleteOnSubmit(new ReportTable(report));
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

        public List<Report> GetReportsForCar(Car car)
        {
            List<Report> Reports = new List<Report>();
            try { 
            var query =
                from report in this.Connection.Reports
                where ((this.GetBookingByID(report.ReportedBooking).BookedCar.PlateNumber) == car.PlateNumber)
                select report;
            foreach (var SingleReport in query)
            {
                Reports.Add(new Report(SingleReport.ID, this.GetBookingByID(SingleReport.ReportedBooking
                    ), SingleReport.Subject, SingleReport.Message));
            }
            return Reports;
            } catch (Exception e)
            {
                return null;
            }

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
                return new User(query.Name, query.Email, query.PasswordHash,true);
            } catch (Exception e)
            {
                return null;
            }
        }

        public bool AddUser (User user)
        {
            try
            {
                Console.WriteLine(user.LicenseExpiration);
                this.Connection.Users.InsertOnSubmit(new UserTable(user));
                this.Connection.SubmitChanges();
                return true;
            }catch(Exception e)
            {
                throw new FaultException<DatabaseFault>(new DatabaseFault(e.ToString()));
                return false;
            }


        }

        public bool DeleteUser (User user)
        {
            try
            {
                this.Connection.Users.DeleteOnSubmit(new UserTable(user));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<User> GetUsers()
        {

            List<User> Users = new List<User>();
            var query =
                from userz in this.Connection.Users
                select userz;
            
            foreach (var utonto in query)
            {
                Users.Add(new User(utonto.Name, utonto.Email, utonto.PasswordHash,Convert.ToBoolean(utonto.isAdmin)));
            }
            return Users;


        }
        public bool AddService(Service service)
        {
            try
            {
                this.Connection.Services.InsertOnSubmit(new ServiceTable(service));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteService(Service service)
        {
            try
            {
                this.Connection.Services.DeleteOnSubmit(new ServiceTable(service));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool UpdateService(Service UpdatableService)
        {
            try { 
            var updatingService =
                (from serv in this.Connection.Services
                 where serv.ID== UpdatableService.ID
                 select serv)
                 .First();
            updatingService.Kilometers = UpdatableService.Kilometers;
            updatingService.ServicedCar = UpdatableService.ServicedCar.PlateNumber;
            updatingService.TotalSpent = UpdatableService.TotalSpent;
            return true;
        }
            catch (Exception e)
            {
                return false;
            }
    }
        public List<Service> GetServicesForCar (Car car)
        {
            try
            {
                List < Service > RetrievedServices= new List<Service>();
                var query =
                    from serv in this.Connection.Services
                    where serv.ServicedCar == car.PlateNumber
                    select serv;
                foreach (var service in query)
                {
                    RetrievedServices.Add(new Service(this.GetCarByPlate(service.ServicedCar), service.Kilometers, service.TotalSpent));
                }
                return RetrievedServices;
            } catch (Exception e)
            {
                return null;
            }
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
