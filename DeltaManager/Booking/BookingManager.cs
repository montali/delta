using System;
using System.Collections;
using Delta.DeltaManager.CarNS;
using Delta.DeltaManager.Utils;

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
           return true;// return DBManager.BookCar(BookedCar, Start, End);
        }

        public bool DeleteBooking (Booking DeletableBooking, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
           return true;// return DBManager.DeleteBooking(DeletableBooking);
        }

        public bool EndBooking (Booking EndedBooking, int NewKilometers, int Liters)
        {
            EndedBooking.BookedCar.Kilometers = NewKilometers;
            EndedBooking.BookedCar.BurnedLiters = Liters;
           return true;// return DBManager.DeleteBooking(EndedBooking);
        }
    }
}
