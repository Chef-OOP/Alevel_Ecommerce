using ECommerce_Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Api.Filters
{
    public class ValidationFilter
        : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                IEnumerable<ModelError> modelErrors = 
                    context.ModelState.Values.SelectMany(v => v.Errors);
                
                modelErrors.ToList().ForEach(x=> 
                {
                    errorDto.Errors.Add(x.ErrorMessage);
                });
                context.Result = new BadRequestObjectResult(errorDto);
            }
            base.OnActionExecuted(context);
        }
    }
}
