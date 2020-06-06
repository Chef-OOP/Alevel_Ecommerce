using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce_Api.DTOs.BasketDTOs;
using ECommerce_Business.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IOrderItemService orderItemService;
        private readonly IMapper mapper;

        public BasketController(
            IOrderItemService orderItemService,
            IMapper mapper)
        {
            this.orderItemService = orderItemService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket(int customerId)
        {
            var result = await orderItemService.GetList(x => x.CustomerId == customerId);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(mapper.Map<IEnumerable<BasketItemDto>>(result.Data));
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateItem(BasketItemDto dto)
        {
            var oi = (await orderItemService.GetById(dto.Id)).Data;
            oi.Quantity = dto.Quantity;
            
            var result = orderItemService.Update(oi);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Message);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpGet]
        public IActionResult DeleteItem(int itemId)
        {
            var oi = new OrderItem { Id = itemId };
            var result = orderItemService.Delete(oi);
            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.Message);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
            }
            return NoContent();
        }
    }
}