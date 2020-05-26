using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPropertyGroupController : ControllerBase
    {
        private readonly IProductPropertyGroupService productPropertyGroupService;
        private readonly IMapper mapper;

        public ProductPropertyGroupController(
            IProductPropertyGroupService productPropertyGroupService,
            IMapper mapper)
        {
            this.productPropertyGroupService = productPropertyGroupService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = 
                await productPropertyGroupService.GetList();
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<ProductPropertyGroupDto>(result.Data));
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
                await productPropertyGroupService.GetById(id);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<ProductPropertyGroupDto>(result.Data));
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

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Post(ProductPropertyGroupDto model)
        {
            var result =
                await productPropertyGroupService.Add(mapper.Map<ProductPropertyGroup>(model));
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
        public async Task<IActionResult> Put(ProductPropertyGroupDto model)
        {
            var result =
                await productPropertyGroupService.Update(mapper.Map<ProductPropertyGroup>(model));
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
