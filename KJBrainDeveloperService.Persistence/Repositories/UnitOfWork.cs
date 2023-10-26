using KJBrainDeveloperService.Persistence.Common;

namespace KJBrainDeveloperService.Persistence.Repositories
{
    /// <summary>
    /// class that combine database operations(repositories).
    /// </summary>
    public class UnitOfWork : UnitOfWorkBase<DataContext>, IUnitOfWork
    {
        public UnitOfWork(
            DataContext context,
            IUserRepository userRepository,
            ITrainingStatisticsRepository trainingStatisticsRepository,
            IMemoryCardStatisticsRepository memoryCardStatisticsRepository
            ) : base(context)
        {
            UserRepository = userRepository;
            TrainingStatisticsRepository = trainingStatisticsRepository;
            MemoryCardStatisticsRepository = memoryCardStatisticsRepository;
        }

        public virtual IUserRepository UserRepository { get; }
        public virtual ITrainingStatisticsRepository TrainingStatisticsRepository { get; }
        public virtual IMemoryCardStatisticsRepository MemoryCardStatisticsRepository { get; }
    }
}
