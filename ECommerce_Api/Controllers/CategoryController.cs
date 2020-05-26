using AutoMapper;
using ECommerce_Api.DTOs;
using ECommerce_Api.ExtensionMethod;
using ECommerce_Api.Filters;
using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoryController(ICategoryService categoryService, 
            IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await categoryService.GetList();
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<CategoryDto>>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpGet("{masterId}")]
        public async Task<IActionResult> GetMaster(int masterId)
        {
            var result = await categoryService.GetList(x=>x.MasterCategoryId==masterId);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<CategoryDto>>(result.Data));
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
            var result = await categoryService.GetById(id);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<CategoryDto>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

       
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto categoryDto,
            IFormFile fileImage)
        {
            if (fileImage == null)
                ModelState.AddModelError("Image Null", "Image Alanı Boş Geçilemez");

            categoryDto.ImagePath =
                await AlevelExtensions.ReadFile(fileImage, "wwwroot/img/category/");

            var result =
            await categoryService.Add(mapper.Map<Category>(categoryDto));

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
        public async Task<IActionResult> Put(CategoryDto categoryDto,
            IFormFile fileImage)
        {
            categoryDto.Updated = DateTime.Now;

            if (fileImage != null)
                categoryDto.ImagePath = await AlevelExtensions.ReadFile(fileImage, "wwwroot/img/category/");

            var result =
                await categoryService.Update(mapper.Map<Category>(categoryDto));

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
        public IActionResult Delete(CategoryDto categoryDto)
        {
            var result =
                 categoryService.Delete(mapper.Map<Category>(categoryDto));

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
