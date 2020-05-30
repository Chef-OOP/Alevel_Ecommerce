using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Abstarct
{
    public interface IAppUserDal
        : IRepository<AppUser>
    {
        List<OperationClaims> GetClaims(AppUser user);
    }
}
