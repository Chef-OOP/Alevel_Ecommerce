using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    public class EfCategoryDal
        : EfEntityRepository<Category, ECommerceContext>, ICategoryDal
    {
        private readonly ECommerceContext context;
        public EfCategoryDal(ECommerceContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<Category>> GetCategoriesGroup(ProductPropertyGroup model)
        {
            var result = await context
                .ProductGroupCategories
                .Where(x => x.ProductPropertyGroup.Id == model.Id)
                .Select(x => x.CategoryId).ToListAsync();

            var categories = await (from c in context.Categories
                                    from r in result
                                    where c.Id == r
                                    select c).ToListAsync();
            return categories;
        }
    }
}
