using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    public class AddressManager
        : IAddressService
    {
        private readonly IAddressDal addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            this.addressDal = addressDal;
        }

        public async Task<EntityResult> Add(Address model)
        {
            try
            {
                var result = await addressDal
                    .GetAsync(x => x.AppUserId == model.AppUserId);
                if (result != null)
                    return
                        new EntityResult(ResultType.Info, "Bu Kullanıcıın Adress Bilgisi Mevcut");
                if (addressDal.Add(model) > 0)
                    return
                        new EntityResult(ResultType.Success, "Ekleme İşlemi Başarılı");
                return
                    new EntityResult(ResultType.Warning, "Ekleme İşlimi Başarılı");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult(ResultType.Error, "Database Hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<Address>> Address(Guid guid)
        {
            try
            {
                var result = await addressDal.Address(guid);
                if (result != null)
                    return
                        new EntityResult<Address>(result);
                return
                    new EntityResult<Address>(null, ResultType.Info, "Guid ile eşleşen adres bulunamadı");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<Address>(null, ResultType.Error, "Database Hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(Address model)
        {
            //TODO: Doldur
            throw new NotImplementedException();
        }

        public Task<EntityResult<Address>> GetById(int id)
        {
            //TODO: Doldur
            throw new NotImplementedException();
        }

        public Task<EntityResult<List<Address>>> GetList(Expression<Func<Address, bool>> filter = null)
        {
            //TODO: Doldur
            throw new NotImplementedException();
        }

        public Task<EntityResult> Update(Address model)
        {
            //TODO: Doldur
            throw new NotImplementedException();
        }
    }
}
