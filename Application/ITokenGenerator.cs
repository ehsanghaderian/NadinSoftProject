using DomainModel.Users;

namespace Application
{
    public interface ITokenGenerator
    {
        string Generate(User user);
    }
}