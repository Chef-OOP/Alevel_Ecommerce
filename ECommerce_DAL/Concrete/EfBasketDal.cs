using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    public class EfBasketDal
    {
        private readonly ECommerceContext Context;
        private readonly IHttpContextAccessor httpContext;

        public EfBasketDal(
            ECommerceContext context, 
            IHttpContextAccessor httpContext)
        {
            Context = context;
            this.httpContext = httpContext;
        }
        public void AddToBasket(Product product)
        {
            //User.

            var cookie =
                httpContext.HttpContext.Request.Cookies["customerKey"];
            if (cookie == null)
            {
                Customer customer = new Customer() { Key = Guid.NewGuid().ToString() };
                Context.Customers.Add(customer);
                if (Context.SaveChanges() > 0)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.HttpOnly = false;
                    cookieOptions.Expires = DateTime.Now.AddDays(2);

                    httpContext
                        .HttpContext
                        .Response
                        .Cookies
                        .Append("customerKey", customer.Key, cookieOptions);
                }

            }
            else
            {
                var cookiesValue =
                    httpContext.HttpContext.Request.Cookies["customerKey"];
                Customer c = Context.Customers.FirstOrDefault(x => x.Key == cookiesValue);
                if (c == null)
                {
                    //Bir Terslik Var
                }
                else
                {

                }
            }


        }
    }
}
