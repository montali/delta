using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Delta.DeltaDBManager.UserNS {
    public class User
    {
        // Properties
        public string Name
        { get; set; }
        public string Email
        { get; set; }
        public string License
        { get; set; }
        public short LicensePoints
        { get; set; }
        DateTime LicenseExpiration
        { get; set; }
        public string PasswordHash
        { get; set; }

        public User(string Name, string Email, string PasswordHash)
        {
            this.Name = Name;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
        }


    }
}