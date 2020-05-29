using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    public class EfAddressDal
        : EfEntityRepository<Address, ECommerceContext>, IAddressDal
    {
        private readonly ECommerceContext context;
        public EfAddressDal(ECommerceContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Address> Address (Guid guid)
        {
            return 
                await context.Addresses.FirstOrDefaultAsync(x => x.AddressKey == guid);
        }

    }
}
