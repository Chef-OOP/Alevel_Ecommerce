using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface ISliderImageService
    {
        Task<EntityResult<SliderImage>> GetById(int id);
        Task<EntityResult<List<SliderImage>>> GetList(Expression<Func<SliderImage, bool>> filter = null);
        Task<EntityResult> Add(SliderImage model);
        EntityResult Delete(SliderImage model);
    }
}
