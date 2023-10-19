using KJBrainDeveloperService.Persistence.Entities;

namespace KJBrainDeveloperService.Business
{
    public interface IAuthTokenService
    {
        string CreateToken(User user);
    }
}
