using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Concrete.POCO
{
    // 2 ayrı sepet (anonim ve login)
    // sepeti cookiede tutacağz (loginden sonra taşımak için)
    // anonim müşteri sepete ürün eklediği anda oluşacak
    public class Basket
    {
        //TODO :  Database eklenmedi
        public List<OrderItem> Items { get; set; }
        public Guid Id { get; set; }
        public int UserId { get; set; } = 0;
    }
}
