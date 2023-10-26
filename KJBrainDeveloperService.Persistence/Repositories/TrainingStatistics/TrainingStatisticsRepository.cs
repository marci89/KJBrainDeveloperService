using KJBrainDeveloperService.Persistence.Common;
using KJBrainDeveloperService.Persistence.Entities;

namespace KJBrainDeveloperService.Persistence.Repositories
{

    /// <summary>
    ///  TrainingStatistics repository with generic
    /// </summary>
    public class TrainingStatisticsRepository : GenericRepository<DataContext, TrainingStatistics>, ITrainingStatisticsRepository
    {
        public TrainingStatisticsRepository(DataContext dbContext) : base(dbContext) { }
    }
}
