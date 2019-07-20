using System;
using System.Collections;
using Delta.DeltaManager.Utils;

namespace Delta.DeltaManager.UserNS
{
    public class UserManager
    {

        public UserManager()
        {
        }

        public bool LoginChecker(Hashtable Authorization)
        {
            User LoggedUser=null;
            //loggedUser= --> QUERY A DB PER USER
            if (LoggedUser != null)
                return true;
            else
                return false;
        }

        public bool IsAdmin(Hashtable Authorization)
        {
            User loggedUser = null;//DBManager.GetCurrentUserFromDB(Authorization);
            //if (User.IsAdmin())
              //  return true;
            //else
                return false;
        }

        public bool CreateUser(string Name, string Email, string PassHash)
        {
            User NewUser = new User(Name, Email, PassHash);
           return true;// return DBManager.CreateUser;
        }

        public bool DeleteUser(User DeletableUser, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
           return true;// return DBManager.DeleteUser(User.email);
        }

        public bool UpdateUser(User UpdatableUser, Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return false;
            }
           return true;// return DBManager.UpdateUser(UpdatableUser);
        }

        public ArrayList GetUsers(Hashtable Authorization)
        {
            try
            {
                DataValidator.CheckAuthorization(Authorization);
            }
            catch (UserNotAuthorizedException e)
            {
                return null;
            }
           return null;// return DBManager.GetUsers();
        }
    }

}