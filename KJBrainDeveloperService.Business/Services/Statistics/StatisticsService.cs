using KJBrainDeveloperService.Persistence.Repositories;
using KJBrainDeveloperService.ServiceContracts;
using Microsoft.EntityFrameworkCore;

namespace KJBrainDeveloperService.Business
{
    /// <summary>
    /// Managing learn statistics
    /// </summary>
    public class StatisticsService : IStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StatisticsFactory _factory;
        private readonly StatisticsValidator _validator;

        public StatisticsService(
            IUnitOfWork unitOfWork,
            StatisticsFactory factory,
            StatisticsValidator validator
            )
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
            _validator = validator;
        }


        #region Training

        /// <summary>
        /// List Training statistics by user id
        /// </summary>
        public async Task<ListTrainingStatisticsResponse> ListTraining(long userId)
        {
            try
            {
                var entities = await _unitOfWork.TrainingStatisticsRepository.Query(x => x.UserId == userId).OrderBy(x => x.Created).ToListAsync();

                return await Task.FromResult(new ListTrainingStatisticsResponse
                {
                    StatusCode = StatusCode.Ok,
                    Result = entities.Select(x => _factory.Create(x)).ToList()
                });
            }
            catch (Exception ex)
            {
                return await _validator.CreateServerErrorResponse<ListTrainingStatisticsResponse>(ex.Message);
            }
        }

        /// <summary>
        /// List Training statistics for chart by user id and filter
        /// </summary>
        public async Task<ListTrainingStatisticsChartResponse> ListTrainingForChart(ListTrainingStatisticsChartRequest request, long userId)
        {
            try
            {
                var entities = await _unitOfWork.TrainingStatisticsRepository.Query(x => x.UserId == userId).OrderBy(x => x.Created).ToListAsync();

                return await Task.FromResult(new ListTrainingStatisticsChartResponse
                {
                    StatusCode = StatusCode.Ok,
                    Result = _factory.Create(entities, request.Quantity)
                });
            }
            catch (Exception ex)
            {
                return await _validator.CreateServerErrorResponse<ListTrainingStatisticsChartResponse>(ex.Message);
            }
        }


        /// <summary>
        /// Create Training statistics by logined user id
        /// </summary>
        public async Task<CreateTrainingStatisticsResponse> CreateTraining(CreateTrainingStatisticsRequest request, long userId)
        {
            try
            {
                var validationResult = _validator.IsValidTrainingCreateRequest(request);
                if (!validationResult.HasError)
                {
                    var entity = _factory.Create(request, userId);
                    await _unitOfWork.TrainingStatisticsRepository.CreateAsync(entity);
                    await _unitOfWork.SaveAsync();

                    return new CreateTrainingStatisticsResponse
                    {
                        StatusCode = StatusCode.Created,
                        Result = _factory.Create(entity)
                    };
                }
                return validationResult;
            }
            catch (Exception ex)
            {
                return await _validator.CreateCreationErrorResponse<CreateTrainingStatisticsResponse>(ex.Message);
            }
        }


        /// <summary>
        /// Delete Training statistics by id
        /// </summary>
        public async Task<ResponseBase> DeleteTraining(long id)
        {
            try
            {
                var entity = await _unitOfWork.TrainingStatisticsRepository.ReadAsync(u => u.Id == id);
                if (entity is null)
                {
                    return await _validator.CreateNotFoundResponse<ResponseBase>();
                }

                await _unitOfWork.TrainingStatisticsRepository.DeleteAsync(entity);
                await _unitOfWork.SaveAsync();

                return new ResponseBase();
            }
            catch (Exception ex)
            {
                return await _validator.CreateDeleteErrorResponse<ResponseBase>(ex.Message);
            }
        }

        /// <summary>
        /// Delete all Training statistics by userId
        /// </summary>
        public async Task<ResponseBase> DeleteAllTraining(long userId)
        {
            try
            {
                var entities = await _unitOfWork.TrainingStatisticsRepository.Query(x => x.UserId == userId).ToListAsync();
                var validationResult = _validator.IsValidTrainingStatisticsList(entities);
                if (validationResult.HasError)
                {
                    return validationResult;
                }
                await _unitOfWork.TrainingStatisticsRepository.DeleteManyAsync(entities);
                await _unitOfWork.SaveAsync();

                return new ResponseBase();
            }
            catch (Exception ex)
            {
                return await _validator.CreateDeleteErrorResponse<ResponseBase>(ex.Message);
            }
        }

        #endregion


        #region MemoryCard

        /// <summary>
        /// List MemoryCard statistics by user id
        /// </summary>
        public async Task<ListMemoryCardStatisticsResponse> ListMemoryCard(long userId)
        {
            try
            {
                var entities = await _unitOfWork.MemoryCardStatisticsRepository.Query(x => x.UserId == userId).OrderBy(x => x.Created).ToListAsync();

                return await Task.FromResult(new ListMemoryCardStatisticsResponse
                {
                    StatusCode = StatusCode.Ok,
                    Result = entities.Select(x => _factory.Create(x)).ToList()
                });
            }
            catch (Exception ex)
            {
                return await _validator.CreateServerErrorResponse<ListMemoryCardStatisticsResponse>(ex.Message);
            }
        }

        /// <summary>
        /// List MemoryCard statistics for chart by user id and filter
        /// </summary>
        public async Task<ListMemoryCardStatisticsChartResponse> ListMemoryCardForChart(ListMemoryCardStatisticsChartRequest request, long userId)
        {
            try
            {
                var entities = await _unitOfWork.MemoryCardStatisticsRepository.Query(x => x.UserId == userId).OrderBy(x => x.Created).ToListAsync();

                return await Task.FromResult(new ListMemoryCardStatisticsChartResponse
                {
                    StatusCode = StatusCode.Ok,
                    Result = _factory.Create(entities, request.Quantity)
                });
            }
            catch (Exception ex)
            {
                return await _validator.CreateServerErrorResponse<ListMemoryCardStatisticsChartResponse>(ex.Message);
            }
        }


        /// <summary>
        /// Create MemoryCard statistics by logined user id
        /// </summary>
        public async Task<CreateMemoryCardStatisticsResponse> CreateMemoryCard(CreateMemoryCardStatisticsRequest request, long userId)
        {
            try
            {
                var validationResult = _validator.IsValidMemoryCardCreateRequest(request);
                if (!validationResult.HasError)
                {
                    var entity = _factory.Create(request, userId);
                    await _unitOfWork.MemoryCardStatisticsRepository.CreateAsync(entity);
                    await _unitOfWork.SaveAsync();

                    return new CreateMemoryCardStatisticsResponse
                    {
                        StatusCode = StatusCode.Created,
                        Result = _factory.Create(entity)
                    };
                }
                return validationResult;
            }
            catch (Exception ex)
            {
                return await _validator.CreateCreationErrorResponse<CreateMemoryCardStatisticsResponse>(ex.Message);
            }
        }


        /// <summary>
        /// Delete MemoryCard statistics by id
        /// </summary>
        public async Task<ResponseBase> DeleteMemoryCard(long id)
        {
            try
            {
                var entity = await _unitOfWork.MemoryCardStatisticsRepository.ReadAsync(u => u.Id == id);
                if (entity is null)
                {
                    return await _validator.CreateNotFoundResponse<ResponseBase>();
                }

                await _unitOfWork.MemoryCardStatisticsRepository.DeleteAsync(entity);
                await _unitOfWork.SaveAsync();

                return new ResponseBase();
            }
            catch (Exception ex)
            {
                return await _validator.CreateDeleteErrorResponse<ResponseBase>(ex.Message);
            }
        }

        /// <summary>
        /// Delete all MemoryCard statistics by userId
        /// </summary>
        public async Task<ResponseBase> DeleteAllMemoryCard(long userId)
        {
            try
            {
                var entities = await _unitOfWork.MemoryCardStatisticsRepository.Query(x => x.UserId == userId).ToListAsync();
                var validationResult = _validator.IsValidMemoryCardStatisticsList(entities);
                if (validationResult.HasError)
                {
                    return validationResult;
                }
                await _unitOfWork.MemoryCardStatisticsRepository.DeleteManyAsync(entities);
                await _unitOfWork.SaveAsync();

                return new ResponseBase();
            }
            catch (Exception ex)
            {
                return await _validator.CreateDeleteErrorResponse<ResponseBase>(ex.Message);
            }
        }

        #endregion
    }
}
