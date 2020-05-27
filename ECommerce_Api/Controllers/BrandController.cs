using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Api.DTOs;
using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;
        private readonly IMapper mapper;

        public BrandController(
            IBrandService brandService,
            IMapper mapper)
        {
            this.brandService = brandService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =
                await brandService.GetList();
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<BrandDto>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
                default:
                    return BadRequest(result.Message);
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var result =
                await brandService.GetById(id);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<BrandDto>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
                default:
                    return BadRequest(result.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProduct(List<Product> products)
        {
            var result = brandService.Brands(products);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<BrandDto>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
                default:
                    return BadRequest(result.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(BrandDto brand)
        {
            var result =
                await brandService.Add(mapper.Map<Brand>(brand));
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Message);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
                default:
                    return BadRequest(result.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(BrandDto brand)
        {
            var result =
                await brandService.Update(mapper.Map<Brand>(brand));
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Message);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    return BadRequest(result.Message);
                case ResultType.Warning:
                    return BadRequest(result.Message);
                default:
                    return BadRequest(result.Message);
            }
        }
    }
}
