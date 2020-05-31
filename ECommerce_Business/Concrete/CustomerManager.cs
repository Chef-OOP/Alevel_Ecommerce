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
    public class CustomerManager
        : ICustomerService
    {
        private readonly ICustomerDal customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }
        public async Task<EntityResult> Add(Customer model)
        {
            try
            {
                var result = await customerDal.GetAsync(x => x.Id == model.Id);
                if (result != null)
                    return
                        new EntityResult(ResultType.Info, "Müşteri Mevcut");
                if (customerDal.Add(model) > 0)
                    return
                        new EntityResult();
                return
                    new EntityResult(ResultType.Warning, "Ekleme işlemi Başarısız");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult(ResultType.Error, "Database Hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<Customer>> Customer(string Key)
        {
            try
            {
                var customer = await customerDal.Customer(Key);
                if (customer != null)
                    return new EntityResult<Customer>(customer);
                return new EntityResult<Customer>(null, ResultType.Info, "Belirtilen Key için Customer Bulunamadı");

            }
            catch (Exception ex)
            {
                return
                    new EntityResult<Customer>(null, ResultType.Error, "Database Hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(Customer model)
        {
            //TODO Doldur
            throw new NotImplementedException();
        }

        public async Task<EntityResult<Customer>> GetById(int id)
        {
            try
            {
                var result = await customerDal.GetAsync(x => x.Id == id);
                if (result != null)
                    return
                        new EntityResult<Customer>(result);
                return
                    new EntityResult<Customer>(null, ResultType.Notfound, "Müşteri bulunamadı");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<Customer>(null, ResultType.Error, "Database Hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<Customer>> GetByUserId(int id)
        {
            try
            {
                Customer customer = await customerDal.GetByUserId(id);
                if (customer != null)
                    return
                        new EntityResult<Customer>(customer);
                return
                    new EntityResult<Customer>(null, ResultType.Notfound, "Customer Bulunamadı");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<Customer>(null, ResultType.Error, "Database Hatası: " + ex.Message);
            }
        }

        public Task<EntityResult<List<Customer>>> GetList(Expression<Func<Customer, bool>> filter = null)
        {
            //TODO Doldur
            throw new NotImplementedException();
        }

        public Task<EntityResult> Update(Customer model)
        {
            //TODO Doldur
            throw new NotImplementedException();
        }
    }
}
