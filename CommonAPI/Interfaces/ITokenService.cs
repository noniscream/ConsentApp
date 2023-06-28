using CommonAPI.Entities;

namespace CommonAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}