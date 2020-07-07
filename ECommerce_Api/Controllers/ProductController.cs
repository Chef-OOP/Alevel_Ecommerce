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
using Microsoft.EntityFrameworkCore.Diagnostics;
using MoreLinq.Extensions;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IProductImageService productImageService;
        private readonly IMapper mapper;
        private readonly IProductPropertyProductsService productPropertyProductsService;
        
        public ProductController(IProductService productService,
            IProductImageService productImageService,
            IMapper mapper,
            IProductPropertyProductsService productPropertyProductsService)
        {
            this.productService = productService;
            this.productImageService = productImageService;
            this.mapper = mapper;
            this.productPropertyProductsService = productPropertyProductsService;
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
            return Content("null");
        }//Listeler

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                 await productService.GetById(id);

            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<ProductDto>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }//Tek Ürün getirir

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Post(
             [FromForm] ProductDto product,
             [FromForm] int[] productProperty,
             [FromForm] IFormFile[] file)
        {
            if (file.Length <= 0)
                ModelState.AddModelError("File Null", "Resim Boş Gelemez");
            if (productProperty.Length <= 0)
                ModelState.AddModelError("Özellik", "Özellikler Tablosu boş gelemez");

            var result =
                await productService.AddProduct(mapper.Map<Product>(product));

            switch (result.ResultType)
            {
                case ResultType.Success:
                    for (int i = 0; i < productProperty.Length; i++)
                    {
                        await productPropertyProductsService
                            .Add(new ProductPropertyProduct()
                            {
                                ProductId = result.Data.Id,
                                ProductPropertyId = productProperty[i]
                            });
                    }

                    for (int i = 0; i < file.Length; i++)
                    {
                        await productImageService.Add(new ProductImage()
                        {
                            Path = await AlevelExtensions.ReadFile(file[i], "wwwroot/img/product/"),
                            ProductId = result.Data.Id
                        });
                    }

                    return Created("NULLL", result.Message);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }//Ürün ekler

        [HttpPut]
        public async Task<IActionResult> Put(ProductDto product)
        {
            var result =
                await productService.Update(mapper.Map<Product>(product));
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Message);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }//Ürün Günceller

        [HttpGet("brand")]
        public IActionResult Get(
            [FromForm] int[] brand,
            [FromForm] int[] productProperty)
        {
            var result =
                productService.GetListByListBrand(brand, productProperty);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Data);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAdviceds(int count)
        {
            var result =
                await productService.GetAdvicedsByCount(count);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<ProductDto>>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetBestSellings(int count)
        {
            var result =
                 await productService.GetBestSellingsByCount(count);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<ProductDto>>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetBrand(int BrandId)
        {
            var result =
                 await productService.GetBrand(BrandId);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<ProductDto>>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetListByCategory(int CategoryId)
        {
            var result =
                 await productService.GetListByCategory(CategoryId);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Data);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetListDeleted()
        {
            var result =
                 await productService.GetListDeleted();
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Data);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetNewProducts(int count)
        {
            var result = await productService.GetNewProductsByCount(count);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<ProductDto>>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetListBySearch(string searchString,int categoryId)
        {
            var result =
                 await productService.GetListBySearch(searchString,categoryId);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Data);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }


    }
}
