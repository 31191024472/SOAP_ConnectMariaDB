using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_ConnectMariaDB.Entities
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public int Population { get; set; }
    }
}