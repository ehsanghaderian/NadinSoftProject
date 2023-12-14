using Application.Features.UserFeatures.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApi.Controllers;

namespace NadinSoftProject.Host.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsersController : BaseApiController
    {
        public UsersController()
        {
            
        }

        /// <summary>
        /// ثبت نام کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            return OkResult(okResult, await Mediator.Send(command));
        }

        /// <summary>
        /// ورود کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            return OkResult(okResult, await Mediator.Send(command));
        }
    }
}
