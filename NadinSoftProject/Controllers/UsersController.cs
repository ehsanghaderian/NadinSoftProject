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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
