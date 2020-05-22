using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class Basket
    {
        public List<OrderItem> Items { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    public class AnonymousBasket
    {
        public List<OrderItem> Items { get; set; }
        public Guid AnonymousUserId { get; set; }
    }
}
