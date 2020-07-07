using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce_DAL.Concrete
{
    public class EfProductPropertyDal:EfEntityRepository<ProductProperty,ECommerceContext>,IProductPropertyDal
    {
        private readonly ECommerceContext ctx;
        public EfProductPropertyDal(ECommerceContext context) : base(context)
        {
            ctx = context;
        }

        public async Task<List<ProductProperty>> GetListByProductId(int productId)
        {
            var result = (from pp in ctx.ProductPropertyProducts
                         from p in ctx.ProductProperties
                         where pp.ProductId == productId && pp.ProductPropertyId == p.Id
                         select p).Distinct().Include(x=>x.Group);
            return await result.ToListAsync();
        }
    }
}
