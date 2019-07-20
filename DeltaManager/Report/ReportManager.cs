using Delta.DeltaManager.CarNS;
using Delta.DeltaManager.Utils;
using System;
using System.Collections;

namespace Delta.DeltaManager.ReportNS
{


    public class ReportManager
    {
        public ReportManager()
        {

        }
        public bool AddReport (Report report, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
           return true;// return DBManager.AddReport(report);
        }

        public ArrayList retrieveReportsForCar (Car car, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return null;
            }
           return null;// return DBManager.GetReportsForCar(car);
        }
    }
}
