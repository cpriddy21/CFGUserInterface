using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFGUserInterface
{
    internal class Rep
    {
        public String RepNum { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String PostalCode { get; set; }
        public float Commission { get; set; }
        public float Rate { get; set; }

        public String UserName { get; set; }
        public String PW { get; set; }
       
    }
}
