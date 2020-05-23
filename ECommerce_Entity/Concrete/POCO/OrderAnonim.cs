using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Concrete.POCO
{
    public class OrderAnonim
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string CustomerFullName { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public string CargoAddress_City { get; set; }
        public string CargoAddress_District { get; set; }
        public string CargoAddress_Detail { get; set; }
        public string CargoAddress_ZipCode { get; set; }

        public string InvoiceAddress_City { get; set; }
        public string InvoiceAddress_District { get; set; }
        public string InvoiceAddress_Detail { get; set; }
        public string InvoiceAddress_ZipCode { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string TCKN { get; set; }


    }
}
