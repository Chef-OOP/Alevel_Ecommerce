using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    //TODO : BOŞ Methodlar var ve dönüş tipi stringleri dolacak
    public class AppUserManager
        : IAppUserService
    {
        private readonly IAppUserDal appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            //TODO : Doldur
            this.appUserDal = appUserDal;
        }

        public EntityResult Add(AppUser user)
        {
            EntityResult result = null;
            try
            {
                int resultDatabase = appUserDal.Add(user);
                if (resultDatabase > 0)
                    return result = new EntityResult(message: "");
                else
                    return result = new EntityResult(ResultType.Info, "");
            }
            catch (Exception ex)
            {
                return result = new EntityResult(ResultType.Error, "" + " " + ex.Message);
            }
        }
        public EntityResult Delete(AppUser user)
        {
            EntityResult result = null;
            try
            {
                int resultDatabase = appUserDal.Delete(user);
                if (resultDatabase > 0)
                    return result = new EntityResult(message: "");
                else
                    return result = new EntityResult(ResultType.Info, "");
            }
            catch (Exception ex)
            {
                return result = new EntityResult(ResultType.Error, "" + " " + ex.Message);
            }
        }
        public EntityResult<List<AppUser>> GetAll()
        {
            EntityResult<List<AppUser>> result = null;
            try
            {
                Task<List<AppUser>> users = appUserDal.GetAllAsync();
                if (users != null)
                    return result = new EntityResult<List<AppUser>>(data: users.Result, message: "");
                else
                    return result = new EntityResult<List<AppUser>>(null, ResultType.Notfound, message: "");
            }
            catch (Exception ex)
            {
                return result = new EntityResult<List<AppUser>>(null, ResultType.Error, message: "" + " " + ex.Message);
            }
        }
        public EntityResult<AppUser> GetByEmail(string email)
        {
            try
            {
                Task<AppUser> user = appUserDal.GetAsync(x => x.Email == email);
                if (user.Result != null)
                {
                    return new EntityResult<AppUser>(user.Result);
                }
                return new EntityResult<AppUser>(null, ResultType.Notfound, "");
            }
            catch (Exception ex)
            {
                return new EntityResult<AppUser>(null, ResultType.Error, "" + " " + ex.Message);
            }

        }
        public EntityResult<AppUser> GetById(int id)
        {
            try
            {
                Task<AppUser> user = appUserDal.GetAsync(x => x.Id == id);
                if (user.Result != null)
                {
                    return new EntityResult<AppUser>(user.Result);
                }
                return new EntityResult<AppUser>(null, ResultType.Notfound, "");
            }
            catch (Exception ex)
            {
                return new EntityResult<AppUser>(null, ResultType.Error, "" + " " + ex.Message);
            }
        }
        public EntityResult<List<OperationClaims>> GetClaims(AppUser user)
        {
            try
            {
                List<OperationClaims> claims = appUserDal.GetClaims(user);
                if (claims != null)
                {
                    return new EntityResult<List<OperationClaims>>(claims);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        public EntityResult Update(AppUser user)
        {
            throw new NotImplementedException();
        }

       
    }
}
