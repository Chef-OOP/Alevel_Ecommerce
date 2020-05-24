using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
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
    public class MasterCategoryController : ControllerBase
    {
        private readonly IMasterCategoryService masterCategoryService;
        private readonly IMapper mapper;

        public MasterCategoryController(
            IMasterCategoryService masterCategoryService,
            IMapper mapper)
        {
            this.masterCategoryService = masterCategoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            var result = await masterCategoryService.GetList();
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<MasterCategoryDto>>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return BadRequest("null");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result =await masterCategoryService.GetById(id);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<MasterCategoryDto>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return null;
        }



        [HttpPost]
        public async Task<IActionResult> Post(MasterCategoryDto masterCategoryDto)
        {
                var result =
                await masterCategoryService.Add(mapper.Map<MasterCategory>(masterCategoryDto));

                switch (result.ResultType)
                {
                    case ResultType.Success:
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



        [HttpPut]
        public async Task<IActionResult> Put(MasterCategoryDto masterCategoryDto)
        {
            masterCategoryDto.Updated = DateTime.Now;
            var result =
                await masterCategoryService.Update(mapper.Map<MasterCategory>(masterCategoryDto));

            switch (result.ResultType)
            {
                case ResultType.Success:
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
