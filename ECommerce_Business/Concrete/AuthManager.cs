using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using ECommerce_Entity.DTOs;
using ECommerce_JWT.Security;
using ECommerce_JWT.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    public class AuthManager
        : IAuthService
    {
        private readonly IAppUserService userService;
        private readonly ITokenHelper tokenHelper;
        public AuthManager(IAppUserService userService, ITokenHelper tokenHelper)
        {
            this.userService = userService;
            this.tokenHelper = tokenHelper;
        }
        public EntityResult<AccessToken> CreateAccessToken(AppUser user)
        {
            EntityResult<AccessToken> result = null;
            try
            {
                var accessToken = tokenHelper.CreateToken(user, userService.GetClaims(user).Data);
                if (accessToken != null)
                {
                    return result = new EntityResult<AccessToken>(accessToken);
                }
                else
                {
                    return result = new EntityResult<AccessToken>(null, ResultType.Info, "Token Üretielemdi");
                }
            }
            catch (Exception ex)
            {
                return result = new EntityResult<AccessToken>(null, ResultType.Error, "Database Hatası: " + ex.Message);
            }
        }

        public EntityResult<AppUser> Login(UserForLoginDto userForLoginDto)
        {
            EntityResult<AppUser> result = null;
            try
            {
                AppUser user = userService.GetByEmail(userForLoginDto.Email).Data;
                if (user == null)
                {
                    result = new EntityResult<AppUser>(null, ResultType.Notfound, message: "(Kullanıcı Bulunamadı) ");
                }
                else
                {
                    if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        result = new EntityResult<AppUser>(null, ResultType.Info, message: "(Kullanıcı Şifre Hatalı) ");
                    }
                    else
                    {
                        result = new EntityResult<AppUser>(user);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new EntityResult<AppUser>(null, ResultType.Error, "Database Hatası: " + ex.Message);
            }
            return result;
        }

        public EntityResult<AppUser> Register(UserForRegisterDto userForRegisterDto)
        {
            EntityResult<AppUser> result = null;
            if (UserExists(userForRegisterDto.Email).ResultType == ResultType.Success)
            {
                byte[] passwordHash;
                byte[] passwordSalt;
                HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
                AppUser user = new AppUser()
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = false//TODO : doğrulama mailinden sonra ture olacak

                    //TODO:BaseModel Oluşturulacak
                };
                userService.Add(user);
                AppUser u =userService.GetByEmail(userForRegisterDto.Email).Data;
                result = new EntityResult<AppUser>(u);
                //TODO : Email Controlu Bu Noktada Yapılcak 
            }
            else
            {
                result = new EntityResult<AppUser>(null, ResultType.Info, "Kullanıcı Mevcut");
            }
            return result;
        }

        public EntityResult UserExists(string email)
        {
            if (userService.GetByEmail(email).Data != null)
            {
                return new EntityResult(ResultType.Info, " Kullanıcı Mevcut");
            }
            return new EntityResult();
        }
    }
}
