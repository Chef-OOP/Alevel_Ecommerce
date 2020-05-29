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
    public class InvoiceManager
        : IInvoiceService
    {
        private readonly IInvoiceDal invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            this.invoiceDal = invoiceDal;
        }
        public async Task<EntityResult> Add(Invoice model)
        {
            //TODO Doldur
            return null;
        }

        public EntityResult Delete(Invoice model)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResult<Invoice>> GetById(int id)
        {
            //TODO Doldur
            throw new NotImplementedException();
        }

        public Task<EntityResult<List<Invoice>>> GetList(Expression<Func<Invoice, bool>> filter = null)
        {
            //TODO Doldur
            throw new NotImplementedException();
        }

        public Task<EntityResult> Update(Invoice model)
        {
            //TODO Doldur
            throw new NotImplementedException();
        }
    }
}
