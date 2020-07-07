using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Api.DTOs;
using ECommerce_Api.Filters;
using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoreLinq.Extensions;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductPropertyController : ControllerBase
    {
        private readonly IProductPropertyService productPropertyService;
        private readonly IMapper mapper;

        public ProductPropertyController(
            IProductPropertyService productPropertyService,
            IMapper mapper)
        {
            this.productPropertyService = productPropertyService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =
                await productPropertyService.GetList();
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<ProductPropertyDto>(result.Data));
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
                await productPropertyService.GetById(id);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<ProductPropertyDto>(result.Data));
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
        public async Task<IActionResult> Post(ProductPropertyDto productPropertyDto)
        {
            var result =
                await productPropertyService.Add(mapper.Map<ProductProperty>(productPropertyDto));
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
        public async Task<IActionResult> Put(ProductPropertyDto productPropertyDto)
        {
            var result =
                await productPropertyService.Update(mapper.Map<ProductProperty>(productPropertyDto));
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

        public async Task<IActionResult> GetGroup(ProductPropertyGroup group)
        {
            var result =
                await productPropertyService.GetList(x => x.GroupId == group.Id);
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
                default:
                    return BadRequest(result.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetListByProductId(int productId)
        {
            var result = await productPropertyService.GetListByProductId(productId);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<List<ProductPropertyDto>>(result.Data));
                default:
                    return BadRequest(result.Message);
            }
        }

    }
}
