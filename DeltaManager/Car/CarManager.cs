using System;
using System.Collections;
using Delta.DeltaManager.Utils;

namespace Delta.DeltaManager.CarNS {
    public class CarManager
    {
        public CarManager()
        {
        }

        public bool AddCar(Car car, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
           return true;// return DBManager.AddCar(car);
        }

        public bool DeleteCar(Car car, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
           return true;// return DBManager.DeleteCar(car);
        }

        public ArrayList GetCars (Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return null;
            }
           return null;// return DBManager.GetCars();
        }

        public bool UpdateCar (Car UpdatableCar, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
           return true;// return DBManager.UpdateCar(UpdatableCar);
        }

        public ArrayList GetAvailableCars(DateTime Start, DateTime End, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return null;
            }
           return null;// return DBManager.GetAvailableCars(Start, End);
        }
    }
}