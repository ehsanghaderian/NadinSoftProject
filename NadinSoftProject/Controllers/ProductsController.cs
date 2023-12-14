using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries.Handlers;
using Infrastructure.Helpers.PaginationHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace NadinSoftProject.Host.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : BaseApiController
    {
        /// <summary>
        /// دریافت اطلاعات کلی محصولات با Pagination
        /// </summary>
        /// <param name="pageQuery"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProductsBriefInfoAsync([FromQuery] PageQuery pageQuery)
        {
            var query = new GetAllProductsInfoQuery { PageQuery = pageQuery };
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// دریافت اطلاعات جزئی محصول با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(Guid id)
        {
            var query = new GetProductInfoQuery { ProductId = id };
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// افزودن محصول جدید
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductCommand command)
        {
            command.CommandSender = this.UserInfo;
            command.Validate();

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// ویرایش محصول
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductByIdAsync(UpdateProductCommand command , Guid id)
        {
            command.Id = id;
            command.CommandSender = this.UserInfo;
            command.Validate();

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// حذف محصول
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(DeleteProductCommand command , Guid id)
        {
            command.Id = id;
            command.CommandSender = this.UserInfo;
            command.Validate();

            return Ok(await Mediator.Send(command));
        }
    }
}
