using DorePardaz.Infrastructure.Extensions;
using Infrastructure.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NadinSoftProject.Host.Messages;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class BaseApiController : ControllerBase
    {
        protected string okResult = "عملیات با موفقیت انجام شد."; 

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public UserInfo UserInfo => (User.Identity as ClaimsIdentity).GetUserInfo();

        [NonAction]
        protected IActionResult OkResult(string message)
        {
            return Ok(new ResponseMessage(message));
        }

        [NonAction]
        protected IActionResult OkResult(string message, object content)
        {
            return Ok(new ResponseMessage(message, content));
        }
    }
}