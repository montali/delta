using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Delta.DeltaDBManager.BookingNS;
using Delta.DeltaDBManager.CarNS;
using Delta.DeltaManager.UserNS;

namespace Delta.DeltaDBManager
{
    class DBManager
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
                updatingCar.PlateNumber = updatableCar.PlateNumber;
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
    }
}
