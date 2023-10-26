using KJBrainDeveloperService.Persistence.Common;

namespace KJBrainDeveloperService.Persistence.Repositories
{
    /// <summary>
    /// Interface of classes that combine database operations(repositories).
    /// </summary>
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IUserRepository UserRepository { get; }
        ITrainingStatisticsRepository TrainingStatisticsRepository { get; }
        IMemoryCardStatisticsRepository MemoryCardStatisticsRepository { get; }
    }
}
