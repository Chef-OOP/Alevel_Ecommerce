using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Invoice
    {
        public Invoice()
        {
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
