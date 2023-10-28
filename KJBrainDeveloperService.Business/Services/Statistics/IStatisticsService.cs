using KJBrainDeveloperService.ServiceContracts;

namespace KJBrainDeveloperService.Business
{
    public interface IStatisticsService
    {
        Task<ReadDailyTrainingStatisticsResponse> ReadDailyTraining(long userId);
        Task<ListTrainingStatisticsChartResponse> ListTrainingForChart(ListTrainingStatisticsChartRequest request, long userId);
        Task<CreateTrainingStatisticsResponse> CreateTraining(CreateTrainingStatisticsRequest request, long userId);
        Task<ResponseBase> DeleteAllTraining(long userId);

        Task<ListMemoryCardStatisticsResponse> ListMemoryCard(long userId);
        Task<ListMemoryCardStatisticsChartResponse> ListMemoryCardForChart(ListMemoryCardStatisticsChartRequest request, long userId);
        Task<CreateMemoryCardStatisticsResponse> CreateMemoryCard(CreateMemoryCardStatisticsRequest request, long userId);
        Task<ResponseBase> DeleteAllMemoryCard(long userId);
    }
}