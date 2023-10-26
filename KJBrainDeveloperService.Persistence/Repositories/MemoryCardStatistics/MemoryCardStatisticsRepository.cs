using KJBrainDeveloperService.Persistence.Common;
using KJBrainDeveloperService.Persistence.Entities;

namespace KJBrainDeveloperService.Persistence.Repositories
{

    /// <summary>
    ///  MemoryCardStatistics repository with generic
    /// </summary>
    public class MemoryCardStatisticsRepository : GenericRepository<DataContext, MemoryCardStatistics>, IMemoryCardStatisticsRepository
    {
        public MemoryCardStatisticsRepository(DataContext dbContext) : base(dbContext) { }
    }
}
