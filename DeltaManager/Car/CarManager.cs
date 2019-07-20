using System;
using System.Collections;
using Delta.DeltaManager.Car;

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
                return null;
            }
            return DBManager.AddCar(car);
        }

        public bool DeleteCar(Car car)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return null;
            }
            return DBManager.DeleteCar(car);
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
            return DBManager.GetCars();
        }

        public bool UpdateCar (Car updatableCar, Hashtable authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return null;
            }
            return DBManager.updateCar(updatableCar);
        }

        public ArrayList getAvailableCars(DateTime start, DateTime end)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return null;
            }
            return DBManager.getAvailableCars(start, end);
        }
    }
}