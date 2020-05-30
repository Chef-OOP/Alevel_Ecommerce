using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    public class EfAppUserDal
        : EfEntityRepository<AppUser, ECommerceContext>, IAppUserDal
    {
        public EfAppUserDal(ECommerceContext context) : base(context)
        {
        }

        public List<OperationClaims> GetClaims(AppUser user)
        {
            using (var con = Context)
            {
                var OperationClaims = from OperationClaim in con.OperationClaims
                                      join UserOperationClaim in con.UserOperationClaims
                                      on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                                      where UserOperationClaim.UserId == user.Id
                                      select new OperationClaims
                                      {
                                          Id = OperationClaim.Id,
                                          Name = OperationClaim.Name
                                      };
                return OperationClaims.ToList();
            }
        }
    }
}
