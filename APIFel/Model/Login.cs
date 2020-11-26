using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIFel.Model
{
    [DataContract]
    public class Login
    {
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public string Token { get; set; }

    }
}