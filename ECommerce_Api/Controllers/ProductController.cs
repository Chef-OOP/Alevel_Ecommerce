using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Api.DTOs;
using ECommerce_Api.ExtensionMethod;
using ECommerce_Api.Filters;
using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IProductImageService productImageService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService,
            IProductImageService productImageService,
            IMapper mapper)
        {
            this.productService = productService;
            this.productImageService = productImageService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await productService.GetList();
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<ProductDto>>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return BadRequest("null");
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Post(ProductDto productDto, IFormFile[] file)
        {
             //TODO : Test Yapıldı sorun yok 

            var result = 
                await productService.AddProduct(mapper.Map<Product>(productDto));

            switch (result.ResultType)
            {
                case ResultType.Success:

                    if (file != null)
                    {
                        for (int i = 0; i < file.Length; i++)
                        {
                            await productImageService.Add(new ProductImage()
                            {
                                Path = await AlevelExtensions.ReadFile(file[i], "wwwroot/img/product/"),
                                ProductId = result.Data.Id
                            });
                        }
                    }
                    return Created("", result.Message);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
