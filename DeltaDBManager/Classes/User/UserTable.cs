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
        public int LicensePoints
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "LicenseExp")]
        public DateTime LicenseExpiration
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "PasswordMD5")]
        public string PasswordHash
        { get; set; }
        [Column(IsPrimaryKey = false, Name = "isAdmin")]
        public int isAdmin
        { get; set; }

        public UserTable(string Name, string Email, string PasswordHash, int isAdmin)
        {
            this.Name = Name;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
            this.isAdmin = isAdmin;
            this.LicenseExpiration = new DateTime(1900, 1, 1);
        }

        public UserTable (User user)
        {
            this.Name = user.Name;
            this.Email = user.Email;
            this.PasswordHash = user.PasswordHash;
            this.License = user.License;
            this.LicensePoints = user.LicensePoints;
            this.LicenseExpiration = user.LicenseExpiration;
            this.isAdmin = Convert.ToInt16(user.isAdmin);
        }

        public UserTable()
        {
            this.Name = null;
            this.Email = null;
            this.PasswordHash = null;
            this.License = null;
            this.LicensePoints = 0;
            this.LicenseExpiration = new DateTime(1900,1,1);
            this.isAdmin = 0;
        }

    }
}