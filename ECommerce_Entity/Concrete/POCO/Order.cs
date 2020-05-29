using ECommerce_Entity.Concrete.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal NetPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymenStatus PaymenStatus { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }


}
