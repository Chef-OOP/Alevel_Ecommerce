using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IAppUserService
    {
        EntityResult<List<OperationClaims>> GetClaims(AppUser user);
        EntityResult<AppUser> GetById(int id);
        EntityResult<List<AppUser>> GetAll();
        EntityResult<AppUser> GetByEmail(string email);
        EntityResult Add(AppUser user);
        EntityResult Delete(AppUser user);//Silme İşlemi Düzenlencek
        EntityResult Update(AppUser user);
    }
}
