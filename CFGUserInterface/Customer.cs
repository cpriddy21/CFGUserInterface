using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace CFGUserInterface
{
	internal class Customer
	{
        public String CustomerNum { get; set; }
        public String CustomerName { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String PostalCode { get; set; }
        public float Balance { get; set; }
        public float CreditLimit { get; set; }
        public String RepNum { get; set; }

    }
}
