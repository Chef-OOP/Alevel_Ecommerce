using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    // TODO: Tamamla
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
