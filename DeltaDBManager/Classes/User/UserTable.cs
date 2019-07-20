using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Delta.DeltaDBManager.UserNS {
    [Table(Name = "User")]
    public class UserTable
    {
        // Properties
        [Column(IsPrimaryKey =false, Name ="Name")]
        public string Name
        { get; set; }
        [Column(IsPrimaryKey = true, Name = "Email")]
        public string Email
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "LicenseNo")]
        public string License
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "LicensePts")]
        public short LicensePoints
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "LicenseExp")]
        DateTime LicenseExpiration
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "PasswordMD5")]
        public string PasswordHash
        { get; set; }

        public UserTable(string Name, string Email, string PasswordHash)
        {
            this.Name = Name;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
        }


    }
}