using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Concrete.POCO
{
    public class AnonymousBasket
    {
        //TODO :  Database eklenmedi
        public List<OrderItem> Items { get; set; }
        public Guid AnonymousUserId { get; set; }
    }
}
