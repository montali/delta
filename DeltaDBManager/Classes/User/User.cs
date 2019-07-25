using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Delta.DeltaDBManager.UserNS {
    [DataContract]
    public class User
    {
        // Properties
        [DataMember]
        public string Name
        { get; set; }
        [DataMember]
        public string Email
        { get; set; }
        [DataMember]
        public string License
        { get; set; }
        [DataMember]
        public short LicensePoints
        { get; set; }
        [DataMember]
        public DateTime LicenseExpiration
        { get; set; }
        [DataMember]
        public string PasswordHash
        { get; set; }
        [DataMember]
        public bool isAdmin
        { get; set; }
        
        public User(string Name, string Email, string PasswordHash, bool isAdmin)
        {
            this.Name = Name;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
            this.isAdmin = isAdmin;
            this.LicenseExpiration = new DateTime(1900, 1, 1);
        }
        public User()
        {
            this.Name = "";
            this.Email = "";
            this.PasswordHash = "";
            this.isAdmin = false;
            this.LicenseExpiration = new DateTime(1900, 1, 1);
        }

    }
}