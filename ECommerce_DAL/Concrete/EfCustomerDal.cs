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
    public class EfCustomerDal
        : EfEntityRepository<Customer, ECommerceContext>, ICustomerDal
    {
        private readonly ECommerceContext context;
        public EfCustomerDal(ECommerceContext context) : base(context)
        {
            this.context = new ECommerceContext();//TODO : Bu Çözülmesi gereken bir sorun IoC devretmeliyiz
        }

        public async Task<Customer> Customer(string Key)
        {
            return await context.Customers.FirstOrDefaultAsync(x => x.Key == Key);
        }

        public async Task<Customer> GetByUserId(int id)
        {
            return await context.Customers.FirstOrDefaultAsync(x=>x.AppUserId==id);
        }

    }
}
