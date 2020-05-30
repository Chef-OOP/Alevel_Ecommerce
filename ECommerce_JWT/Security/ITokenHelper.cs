using ECommerce_Entity.Concrete.POCO;
using System.Collections.Generic;

namespace ECommerce_JWT.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUser user, List<OperationClaims> operationClaims);
    }
}
