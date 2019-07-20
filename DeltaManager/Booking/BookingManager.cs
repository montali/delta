using System;
using Booking;

namespace Delta.DeltaManager.BookingNS
{
    public class BookingManager
    {
        public BookingManager()
        {
        }
        public bool BookCar (Car BookedCar, DateTime Start, DateTime End, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
            return DBManager.BookCar(BookedCar, Start, End);
        }

        public bool deleteBooking (Booking DeletableBooking, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
            return DBManager.DeleteBooking(DeletableBooking);
        }

        public bool endBooking (Booking EndedBooking, int NewKilometers, int Liters)
        {
            EndedBooking.BookedCar.Kilometers = NewKilometers;
            EndedBooking.BookedCar.BurnedLiters = Liters;
            return DBManager.DeleteBooking(EndedBooking);
        }
    }
}
