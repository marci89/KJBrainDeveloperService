using KJBrainDeveloperService.ServiceContracts;
using Entity = KJBrainDeveloperService.Persistence.Entities;

namespace KJBrainDeveloperService.Business
{

    /// <summary>
    /// Validating Statistics object
    /// </summary>
    public class StatisticsValidator : BaseValidator
    {
        /// <summary>
        /// Execute Training Statistics create request validating
        /// </summary>
        public CreateTrainingStatisticsResponse IsValidTrainingCreateRequest(CreateTrainingStatisticsRequest request)
        {
            if (request is null)
                return CreateErrorResponse<CreateTrainingStatisticsResponse>(ErrorMessage.InvalidRequest);

            return new CreateTrainingStatisticsResponse
            {
                StatusCode = StatusCode.Created,
            };
        }

        /// <summary>
        /// Execute Training Statistics list null check validating
        /// </summary>
        public ResponseBase IsValidTrainingStatisticsList(List<Entity.TrainingStatistics> request)
        {
            if (request is null || !request.Any())
                return CreateErrorResponse<ResponseBase>(ErrorMessage.NoElementToModify);

            return new ResponseBase
            {
                StatusCode = StatusCode.Ok,
            };
        }

        /// <summary>
        /// Execute MemoryCard Statistics create request validating
        /// </summary>
        public CreateMemoryCardStatisticsResponse IsValidMemoryCardCreateRequest(CreateMemoryCardStatisticsRequest request)
        {
            if (request is null)
                return CreateErrorResponse<CreateMemoryCardStatisticsResponse>(ErrorMessage.InvalidRequest);

            return new CreateMemoryCardStatisticsResponse
            {
                StatusCode = StatusCode.Created,
            };
        }

        /// <summary>
        /// Execute MemoryCard Statistics list null check validating
        /// </summary>
        public ResponseBase IsValidMemoryCardStatisticsList(List<Entity.MemoryCardStatistics> request)
        {
            if (request is null || !request.Any())
                return CreateErrorResponse<ResponseBase>(ErrorMessage.NoElementToModify);

            return new ResponseBase
            {
                StatusCode = StatusCode.Ok,
            };
        }
    }
}
