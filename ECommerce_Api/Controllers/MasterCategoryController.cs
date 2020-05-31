using AutoMapper;
using ECommerce_Api.DTOs;
using ECommerce_Api.ExtensionMethod;
using ECommerce_Api.Filters;
using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using System.Threading.Tasks;

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
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var a=HttpContext.Request.Headers;
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
            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await masterCategoryService.GetById(id);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<MasterCategoryDto>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromForm] MasterCategoryDto masterCategoryDto,
            [FromForm] IFormFile fileLogo,
            [FromForm] IFormFile fileImage)
        {

            if (fileLogo == null)
                ModelState.AddModelError("Logo Null", "Logo alanı Boş Geöilemez");
            if (fileImage == null)
                ModelState.AddModelError("Image Null", "Image alanı Boş geçilemez");

            if (ModelState.IsValid)
            {
                masterCategoryDto.Logo =
              await AlevelExtensions.ReadFile(fileLogo, "wwwroot/img/masterCategory/");

                masterCategoryDto.Image =
                    await AlevelExtensions.ReadFile(fileImage, "wwwroot/img/masterCategory/");
            }


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
        public async Task<IActionResult> Put(
            MasterCategoryDto masterCategoryDto,
            IFormFile fileLogo,
            IFormFile fileImage)
        {
            masterCategoryDto.Updated = DateTime.Now;

            if (fileImage != null)
                masterCategoryDto.Image =
                await AlevelExtensions.ReadFile(fileImage, "wwwroot/img/masterCategory/");

            if (fileLogo != null)
                masterCategoryDto.Logo =
                await AlevelExtensions.ReadFile(fileLogo, "wwwroot/img/masterCategory/");

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

        [HttpDelete]
        public IActionResult Delete(MasterCategoryDto masterCategoryDto)
        {
            var result =
                 masterCategoryService.Delete(mapper.Map<MasterCategory>(masterCategoryDto));

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
