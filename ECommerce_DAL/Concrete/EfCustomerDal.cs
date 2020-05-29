using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_DAL.Migrations;
using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    public class EfCustomerDal
        : EfEntityRepository<Customer, ECommerceContext>, ICustomerDal
    {
        private readonly ECommerceContext context;
        public EfCustomerDal(ECommerceContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Customer> Customer(string Key)
        {
            return await context.Customers.FirstOrDefaultAsync(x => x.Key == Key);
        }
    }
}
