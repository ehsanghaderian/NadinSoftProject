using Infrastructure.Shared;
using System.Security.Claims;

namespace DorePardaz.Infrastructure.Extensions
{
    public static class TokenExtenstion
    {
        public static UserInfo GetUserInfo(this ClaimsIdentity claimsIdentity)
        {
            return new UserInfo()
            {
                UserName = claimsIdentity.FindFirst("username").Value,
                Name = claimsIdentity.FindFirst(ClaimTypes.Name).Value,
                UserId = Guid.Parse(claimsIdentity.FindFirst("userid").Value),
                Email = claimsIdentity.FindFirst(ClaimTypes.Email).Value,
                PhoneNumber = claimsIdentity.FindFirst("phonenumber").Value,
            };
        }
    }
}
