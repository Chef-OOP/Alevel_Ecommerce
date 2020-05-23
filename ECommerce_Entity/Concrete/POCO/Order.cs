using ECommerce_Entity.Concrete.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Order 
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Address InvoiceAddress { get; set; }
        public Address ShippingAddress { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public OrderStatus Status { get; set; }
    }

    
}
