using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.DeltaManager.ServiceNS
{
    class ServiceManager
    {
    }

    public bool addCarService (Service ServiceDone, Hashtable Authorization)
    {
        try
        {
            DataValidator.CheckAuthorization(Authorization);
        }
        catch (UserNotAuthorizedException e)
        {
            return false;
        }
        return DBManager.addCarService(ServiceDone);
    }

    public ArrayList GetCarServicesForCar (Car ServicedCar)
    {
        try
        {
            DataValidator.CheckAuthorization(Authorization);
        }
        catch (UserNotAuthorizedException e)
        {
            return null;
        }
        return DBManager.getCarServicesForCar(ServicedCar);
    }
}
