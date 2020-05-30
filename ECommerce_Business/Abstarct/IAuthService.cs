using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using ECommerce_Entity.DTOs;
using ECommerce_JWT.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IAuthService
    {
        EntityResult<AppUser> Register(UserForRegisterDto userForRegisterDto);
        EntityResult<AppUser> Login(UserForLoginDto userForLoginDto);
        EntityResult UserExists(string email);
        EntityResult<AccessToken> CreateAccessToken(AppUser user);
    }
}
