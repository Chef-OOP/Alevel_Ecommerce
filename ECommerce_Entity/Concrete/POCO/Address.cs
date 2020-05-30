using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Address : BaseEntity
    {
        public Guid AddressKey { get; set; }
        public string Title { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }
        public string PostalCode { get; set; }
        public bool SameInvoice { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
