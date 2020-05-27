using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    public class EfProductPropertyGroupDal : EfEntityRepository<ProductPropertyGroup, ECommerceContext>, IProductPropertyGroupDal
    {
        private readonly ECommerceContext context;
        public EfProductPropertyGroupDal(ECommerceContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<ProductPropertyGroup>> GetCategoriesGroup(Category model)
        {
            var result = await context
                .ProductGroupCategories
                .Where(x => x.CategoryId == model.Id)
                .Select(x => x.ProductPropertyGroupId)
                .ToArrayAsync();

            return await (from p in context.ProductPropertyGroups
                          from r in result
                          where p.Id == r
                          select p).ToListAsync();

        }
    }
}
