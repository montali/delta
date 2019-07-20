using System;

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
            DBManager.AddReport(report);
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
            return DBManager.GetReportsForCar(car);
        }
    }
}
