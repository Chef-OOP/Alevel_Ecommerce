using AutoMapper;
using ECommerce_Api.DTOs;
using ECommerce_Api.DTOs.BasketDTOs;
using ECommerce_Api.Filters;
using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using ECommerce_Entity.DTOs;
using ECommerce_JWT.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Api.Controllers
{
 

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAddressService addressService;
        private readonly IInvoiceService invoiceService;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        private readonly IAuthService authService;
        private readonly IOrderItemService orderItemService;

        public AuthController(
            IMapper mapper,
            IAddressService addressService,
            IInvoiceService invoiceService,
            ICustomerService customerService,
            IProductService productService,
            IAuthService authService,
            IOrderItemService orderItemService)
        {
            this.mapper = mapper;
            this.addressService = addressService;
            this.invoiceService = invoiceService;
            this.customerService = customerService;
            this.productService = productService;
            this.authService = authService;
            this.orderItemService = orderItemService;
        }

        /// <summary>
        /// Login İşlemi 3 aşamalı olcak
        /// 1. Aşama Direk Login (Site açılır customerKey cookie si yoktur)
        /// 2. Aşama Müşteri kayıtlı user dır. siteye giriş yapmadan sepeti dolurur
        /// ödemeye gelince 3 seçenek sunulur.
        ///     2.1 Login ol devam et(sepet işlemine geçeceği için bir customerKey üretecek 
        ///     ve orderItem oluşacak login olunca orderItem daki product lar user-customer
        ///     tarafına geçecek)
        ///     2.2 üye ol devam et => bu seçenek Register yönlenecek burada işi yok
        ///     2.3 üye olmadan ödemeyi tamamla => Ödeme Sayfasına Yönlencek Burada işi yok  
        /// 3.Aşama customer user değildir. sepetten sonra üye olmak ister ise regitere gidecek
        /// ve customer key korunacak user oluşacak customer key ile ilişkilencek
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            EntityResult<AccessToken> accessToken = null;

            if (userForLoginDto.CustomerId == 0)
            {
                var userResult = authService.Login(userForLoginDto);
                switch (userResult.ResultType)
                {
                    case ResultType.Success:
                        accessToken = authService.CreateAccessToken(userResult.Data);
                        switch (accessToken.ResultType)
                        {
                            case ResultType.Success:
                                var customerResult =
                                    await (customerService.GetByUserId(userResult.Data.Id));
                                switch (customerResult.ResultType)
                                {
                                    case ResultType.Success:
                                        accessToken.Data.CustomerId = customerResult.Data.Id;
                                        break;
                                    case ResultType.Info:
                                        return BadRequest(customerResult.Message);
                                    case ResultType.Error:
                                        return BadRequest(customerResult.Message);
                                    case ResultType.Notfound:
                                        return BadRequest(customerResult.Message);
                                    case ResultType.Warning:
                                        return BadRequest(customerResult.Message);
                                    default:
                                        return BadRequest(customerResult.Message);
                                }
                                return Ok(accessToken.Data);
                            case ResultType.Info:
                                return BadRequest(accessToken.Message);
                            case ResultType.Error:
                                return BadRequest(accessToken.Message);
                            case ResultType.Notfound:
                                return BadRequest(accessToken.Message);
                            case ResultType.Warning:
                                return BadRequest(accessToken.Message);
                            default:
                                return BadRequest(accessToken.Message);
                        }
                    case ResultType.Info:
                        return BadRequest(userResult.Message);
                    case ResultType.Error:
                        return BadRequest(userResult.Message);
                    case ResultType.Notfound:
                        return BadRequest(userResult.Message);
                    case ResultType.Warning:
                        return BadRequest(userResult.Message);
                    default:
                        return BadRequest(userResult.Message);
                }
            }
            else
            {
                var items =
                    (await orderItemService.GetList(x => x.CustomerId == userForLoginDto.CustomerId)).Data;
                var userResult = authService.Login(userForLoginDto);
                var customerID = (await customerService.GetByUserId(userResult.Data.Id)).Data.Id;
                foreach (var item in items)
                {
                    item.CustomerId = customerID;
                    orderItemService.Update(item);
                }

                accessToken = (authService.CreateAccessToken(userResult.Data));



                accessToken.Data.CustomerId = customerID;

                return Ok(accessToken.Data);
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddToBasket(AddToBasketDto addToBasket)
        {
            Customer customerData = null;
            if (addToBasket.CustomerId == 0)
            {
                string key = Guid.NewGuid().ToString();
                Customer customer = new Customer();
                customer.Key = key;
                await customerService.Add(customer);
                customerData = (await customerService.Customer(key)).Data;
            }
            else
            {
                customerData = (await customerService.GetById(addToBasket.CustomerId)).Data;
            }
            var product = (await productService.GetById(addToBasket.Id)).Data;

            var orderItems = (await orderItemService
                .GetList(x => x.CustomerId == customerData.Id)).Data;

                    if (orderItems.Count > 0)
            {
                OrderItem or = orderItems.FirstOrDefault(x => x.ProductId == product.Id);
                if (or != null)
                {
                    or.Quantity += addToBasket.Count;
                    orderItemService.Update(or);
                }
                else
                {
                    OrderItem ori = new OrderItem()
                    {
                        ProductId = product.Id,
                        CustomerId = customerData.Id,
                        Quantity = addToBasket.Count
                    };
                    orderItemService.Add(ori);
                }
            }
            else
            {
                OrderItem ori = new OrderItem()
                {
                    ProductId = product.Id,
                    CustomerId = customerData.Id,
                    Quantity = addToBasket.Count
                };
                orderItemService.Add(ori);
            }
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("Success", true);
            json.Add("customerid", customerData.Id);
            return Ok(json);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromBasket(AddToBasketDto addToBasket)
        {
            Customer customerData = null;
            if (addToBasket.CustomerId == 0)
            {
                string key = Guid.NewGuid().ToString();
                Customer customer = new Customer();
                customer.Key = key;
                await customerService.Add(customer);
                customerData = (await customerService.Customer(key)).Data;
            }
            else
            {
                customerData = (await customerService.GetById(addToBasket.CustomerId)).Data;
            }
            var product = (await productService.GetById(addToBasket.Id)).Data;

            var orderItems = (await orderItemService
                .GetList(x => x.CustomerId == customerData.Id)).Data;

            if (orderItems.Count > 0)
            {
                OrderItem or = orderItems.FirstOrDefault(x => x.ProductId == product.Id);
                if (or != null)
                {
                    or.Quantity = addToBasket.Count;
                    orderItemService.Update(or);
                }
                else
                {
                    OrderItem ori = new OrderItem()
                    {
                        ProductId = product.Id,
                        CustomerId = customerData.Id,
                        Quantity = addToBasket.Count
                    };
                    orderItemService.Delete(ori);
                }
            }
            else
            {
                OrderItem ori = new OrderItem()
                {
                    ProductId = product.Id,
                    CustomerId = customerData.Id,
                    Quantity = addToBasket.Count
                };
                orderItemService.Delete(ori);
            }
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("Success", true);
            json.Add("customerid", customerData.Id);
            return Ok(json);

        }




        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Register(
            [FromForm] UserForRegisterDto userForRegisterDto,
            [FromForm] AddressDto address)
        {
            Dictionary<string, object> json = new Dictionary<string, object>();

            #region Normal Register İşlemi
            EntityResult<AppUser> resultUser = authService.Register(userForRegisterDto);
            switch (resultUser.ResultType)
            {
                case ResultType.Success:
                    break;
                case ResultType.Info:
                    return BadRequest(resultUser.Message);
                case ResultType.Error:
                    return BadRequest(resultUser.Message);
                case ResultType.Notfound:
                    return BadRequest(resultUser.Message);
                case ResultType.Warning:
                    return BadRequest(resultUser.Message);
                default:
                    return BadRequest(resultUser.Message);
            }
            #endregion

            if (userForRegisterDto.CustomerId == 0)
            {

                Customer customer = new Customer();
                ////User Başarı ile oluşturulursa bu raya gelir
                if (resultUser.Data != null)
                {

                    //Eklenen User Databaseden çekliyor
                    AppUser u = resultUser.Data;
                    json.Add("userId", u.Id);
                    if (u != null)
                    {
                        //Register işlemi yapan her User aynı zamanda Customer dır.
                        customer.Key = Guid.NewGuid().ToString();
                        customer.AppUserId = u.Id;
                        customer.Email = u.Email;
                        customer.FirstName = u.FirstName;
                        customer.LastName = u.LastName;
                        customer.CellPhone = u.CellPhone;
                        var resultCustomer =
                            await customerService.Add(customer);
                        //Customer Eklenmesinden Doğacak hataların dönüşü buradan başalar
                        switch (resultCustomer.ResultType)
                        {
                            case ResultType.Success:
                                break;
                            case ResultType.Info:
                                return BadRequest(resultCustomer.Message);
                            case ResultType.Error:
                                return BadRequest(resultCustomer.Message);
                            case ResultType.Notfound:
                                return BadRequest(resultCustomer.Message);
                            case ResultType.Warning:
                                return BadRequest(resultCustomer.Message);
                            default:
                                return BadRequest(resultCustomer.Message);
                        }
                        /*
                         * User Register işlemlerinde Adres Zorunlu tutulcak ve burada
                         * adress tablosuna User ve Customer Id olarak tanımlancak
                         **/
                        address.AddressKey = Guid.NewGuid();
                        address.AppUserId = u.Id;

                        var resultCus = await customerService.Customer(customer.Key);
                        //Eklenen Customer tekrar çağrılıyor ve ve adress tablosuna ekleniyor
                        switch (resultCustomer.ResultType)
                        {
                            case ResultType.Success:
                                address.CustomerId = resultCus.Data.Id;
                                json.Add("customerId", resultCus.Data.Id);
                                break;
                            case ResultType.Info:
                                return BadRequest(resultCus.Message);
                            case ResultType.Error:
                                return BadRequest(resultCus.Message);
                            case ResultType.Notfound:
                                return BadRequest(resultCus.Message);
                            case ResultType.Warning:
                                return BadRequest(resultCus.Message);
                            default:
                                return BadRequest(resultCus.Message);
                        }
                        var resultAdress =
                            await addressService.Add(mapper.Map<Address>(address));
                        //Adress Database ekleme sırasıda doğabilcek hataları kontrol ediyor 
                        switch (resultAdress.ResultType)
                        {
                            case ResultType.Success:
                                break;
                            case ResultType.Info:
                                return BadRequest(resultAdress.Message);
                            case ResultType.Error:
                                return BadRequest(resultAdress.Message);
                            case ResultType.Notfound:
                                return BadRequest(resultAdress.Message);
                            case ResultType.Warning:
                                return BadRequest(resultAdress.Message);
                            default:
                                return BadRequest(resultAdress.Message);
                        }

                        /*Register sırasında User adres bilgilerinin fatura adresi olmasını 
                         * isterse bu kod çalışsın
                         * Eğer istemezse satın alma işleminde fatura bilgisi tekrar istencek
                         */
                        if (address.SameInvoice)
                        {
                            var resultAd = await addressService.Address(address.AddressKey);
                            Address ad = null;
                            switch (resultAd.ResultType)
                            {
                                case ResultType.Success:
                                    ad = resultAd.Data;
                                    break;
                                case ResultType.Info:
                                    return BadRequest(resultAd.Message);
                                case ResultType.Error:
                                    return BadRequest(resultAd.Message);
                                case ResultType.Notfound:
                                    return BadRequest(resultAd.Message);
                                case ResultType.Warning:
                                    return BadRequest(resultAd.Message);
                                default:
                                    return BadRequest(resultAd.Message);
                            }
                            Invoice ınvoice = new Invoice()
                            {
                                CustomerId = address.CustomerId,
                                AddressId = ad.Id
                            };
                            await invoiceService.Add(ınvoice);
                        }


                    }

                }

                json.Add("Success", "Başarılı");
                return Ok(json);
            }
            else if (userForRegisterDto.CustomerId > 0)
            {
                var customer = (await customerService.GetById(userForRegisterDto.CustomerId)).Data;

                if (resultUser.Data != null)
                {

                    AppUser u = resultUser.Data;
                    json.Add("userId", u.Id);
                    if (u != null)
                    {

                        customer.AppUserId = u.Id;
                        customer.Email = u.Email;
                        customer.FirstName = u.FirstName;
                        customer.LastName = u.LastName;
                        customer.CellPhone = u.CellPhone;

                        var resultCustomer =
                            await customerService.Update(customer);
                        switch (resultCustomer.ResultType)
                        {
                            case ResultType.Success:
                                break;
                            case ResultType.Info:
                                return BadRequest(resultCustomer.Message);
                            case ResultType.Error:
                                return BadRequest(resultCustomer.Message);
                            case ResultType.Notfound:
                                return BadRequest(resultCustomer.Message);
                            case ResultType.Warning:
                                return BadRequest(resultCustomer.Message);
                            default:
                                return BadRequest(resultCustomer.Message);
                        }
                        address.AddressKey = Guid.NewGuid();
                        address.AppUserId = u.Id;

                        var resultCus = await customerService.Customer(customer.Key);
                        switch (resultCustomer.ResultType)
                        {
                            case ResultType.Success:
                                address.CustomerId = resultCus.Data.Id;
                                break;
                            case ResultType.Info:
                                return BadRequest(resultCus.Message);
                            case ResultType.Error:
                                return BadRequest(resultCus.Message);
                            case ResultType.Notfound:
                                return BadRequest(resultCus.Message);
                            case ResultType.Warning:
                                return BadRequest(resultCus.Message);
                            default:
                                return BadRequest(resultCus.Message);
                        }
                        var resultAdress =
                            await addressService.Add(mapper.Map<Address>(address));
                        switch (resultAdress.ResultType)
                        {
                            case ResultType.Success:
                                break;
                            case ResultType.Info:
                                return BadRequest(resultAdress.Message);
                            case ResultType.Error:
                                return BadRequest(resultAdress.Message);
                            case ResultType.Notfound:
                                return BadRequest(resultAdress.Message);
                            case ResultType.Warning:
                                return BadRequest(resultAdress.Message);
                            default:
                                return BadRequest(resultAdress.Message);
                        }

                        if (address.SameInvoice)
                        {
                            var resultAd = await addressService.Address(address.AddressKey);
                            Address ad = null;
                            switch (resultAd.ResultType)
                            {
                                case ResultType.Success:
                                    ad = resultAd.Data;
                                    break;
                                case ResultType.Info:
                                    return BadRequest(resultAd.Message);
                                case ResultType.Error:
                                    return BadRequest(resultAd.Message);
                                case ResultType.Notfound:
                                    return BadRequest(resultAd.Message);
                                case ResultType.Warning:
                                    return BadRequest(resultAd.Message);
                                default:
                                    return BadRequest(resultAd.Message);
                            }
                            Invoice ınvoice = new Invoice()
                            {
                                CustomerId = address.CustomerId,
                                AddressId = ad.Id
                            };
                            await invoiceService.Add(ınvoice);
                        }
                    }
                }

                json.Add("Success", "Başarılı");
                json.Add("customerId", userForRegisterDto.CustomerId);

                return Ok(json);
            }
            else
            {
                //TODO : Beklemede
                return BadRequest("Daha Kodlanmadı");
            }

        }

    }
}
