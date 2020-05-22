using ECommerce_Entity.Concrete.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Entity.Concrete.POCO
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; }
    }
}
