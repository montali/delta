using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.DeltaManager.UserNS;

namespace Delta.DeltaManager.Utils
{
    class DataValidator
    {

        public static void CheckAuthorization(Hashtable Authorization) // TODO: Verify ifs throwing exceptions here is ok. 
        {
            User CheckingUser = DBManager.getUserFromEmail(Authorization["Email"]);
            if (CheckingUser.PasswordHash != Authorization["Hash"])
                throw new UserNotAuthorizedException(string.Format("User not authorized to do this."));
        }

        public static bool CheckEmail(string Email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
