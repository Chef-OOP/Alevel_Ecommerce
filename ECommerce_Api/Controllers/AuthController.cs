using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Api.DTOs;
using ECommerce_Api.Filters;
using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using ECommerce_Entity.DTOs;
using ECommerce_JWT.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoreLinq.Extensions;

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

        public AuthController(
            IMapper mapper,
            IAddressService addressService,
            IInvoiceService invoiceService,
            ICustomerService customerService,
            IProductService productService,
            IAuthService authService)
        {
            //this.userManager = user;
            //this.signInManager = signIn;
            this.mapper = mapper;
            this.addressService = addressService;
            this.invoiceService = invoiceService;
            this.customerService = customerService;
            this.productService = productService;
            this.authService = authService;
        }


        [HttpPost]
        [ValidationFilter]
        public IActionResult Login([FromForm] UserForLoginDto userForLoginDto)
        {
            EntityResult<AccessToken> accessToken = null;
            var userResult = authService.Login(userForLoginDto);
            switch (userResult.ResultType)
            {
                case ResultType.Success:
                    accessToken = authService.CreateAccessToken(userResult.Data);
                    switch (accessToken.ResultType)
                    {
                        case ResultType.Success:
                            return Ok(accessToken.Data);
                        case ResultType.Info:
                            break;
                        case ResultType.Error:
                            break;
                        case ResultType.Notfound:
                            break;
                        case ResultType.Warning:
                            break;
                        default:
                            break;
                    }
                    break;
                case ResultType.Info:
                    break;
                case ResultType.Error:
                    break;
                case ResultType.Notfound:
                    break;
                case ResultType.Warning:
                    break;
                default:
                    break;
            }
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> AddToBasket(
            [FromForm] int id,
            [FromForm] int count)
        {
            if (User.Identity.IsAuthenticated)
            {
                Product product = (await productService.GetById(id)).Data;// TODO : BAK

            }
            return null;
        }




        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Register(
            [FromForm] UserForRegisterDto userForRegisterDto,
            [FromForm] AddressDto address)
        {
            var cookie = HttpContext.Request.Cookies["customerKey"];
            if (cookie == null)
            {
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
                Customer customer = new Customer();
                ////User Başarı ile oluşturulursa bu raya gelir
                if (resultUser.Data != null)
                {

                    //Eklenen User Databaseden çekliyor
                    AppUser u = resultUser.Data;
                    if (u != null)
                    {
                        //Register işlemi yapan her User aynı zamanda Customer dır.

                        customer.Key = Guid.NewGuid().ToString();
                        customer.AppUserId = u.Id;
                        customer.Email = u.Email;
                        customer.LastName = u.FirstName;
                        customer.Name = u.LastName;
                        //customer.Phone = u.PhoneNumber;
                        var resultCustomer =
                            await customerService.Add(customer);
                        //Customer Eklemsinden Doğacak hataların dönüşü buradan başalar
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
                         * Eğer istemezse satın alma isşeminde fatura bilgisi tekrar istencek
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

                HttpContext
                    .Response
                    .Cookies
                    .Append("customerKey", customer.Key);
                Dictionary<string, object> json = new Dictionary<string, object>();
                json.Add("Success", "Başarılı");
                return Ok(json);
            }
            else if (cookie != null)
            {
                #region alışverişten Sepetten Yönlendirilen Register işlemi
                //Sepere Ürün ekledikten sonra register olmaya gelen customer
                //TODO: Register Doldur
                #endregion
                return null;
            }
            else
            {
                return BadRequest("Daha Kodlanmadı");
            }

        }

    }
}
