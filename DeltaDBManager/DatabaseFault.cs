using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Delta.DeltaDBManager
{
    [DataContract]
    public class DatabaseFault
    {
        private string _message;

        public DatabaseFault(string message)
        {
            _message = message;
        }

        [DataMember]
        public string Message { get { return _message; } set { _message = value; } }
    }
}
