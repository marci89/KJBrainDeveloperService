using KJBrainDeveloperService.Persistence.Common;
using KJBrainDeveloperService.Persistence.Entities;

namespace KJBrainDeveloperService.Persistence.Repositories
{
    /// <summary>
    /// User repository with generic
    /// </summary>
    public class UserRepository : GenericRepository<DataContext, User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext) { }
    }
}
