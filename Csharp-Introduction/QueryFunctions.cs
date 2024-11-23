using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Introduction
{
    internal class QueryFunctions
    {

    }
    public class Customer 
    { 
        public int? Id { get; set; } 
        public string? Name { get; set; }

    }
    public class Order
    { 
        public string? OrderName { get; set; }
        public int? OrderId { get; set; }
        public int? CustomerId { get; set; }


    }


}
