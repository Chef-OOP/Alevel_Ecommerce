using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public Order OrderId { get; set; }
        public Order Order { get; set; }
    }
}
