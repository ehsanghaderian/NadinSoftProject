using DomainModel.Users;
using Infrastructure.Appsettings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Features.UserFeatures.Commands.Handlers
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, object>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        public UserLoginCommandHandler(UserManager<User> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            this._tokenGenerator = tokenGenerator;
        }

        public async Task<object> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var token = _tokenGenerator.Generate(user);

                return new 
                {
                    Token = token,
                    UserId = user.Id,
                    UserName = user.UserName,
                };
            }
            return null;
        }
    }
}
