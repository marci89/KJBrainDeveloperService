using KJBrainDeveloperService.Persistence.Repositories;
using KJBrainDeveloperService.ServiceContracts;
using Microsoft.EntityFrameworkCore;

using Entity = KJBrainDeveloperService.Persistence.Entities;

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
        public async Task<ReadDailyTrainingStatisticsResponse> ReadDailyTraining(long userId)
        {
            try
            {
                DateTime today = DateTime.UtcNow.Date;

                //tarinings
                var trainings = await _unitOfWork.TrainingStatisticsRepository
                    .Query(x => x.UserId == userId && x.Created.Date == today)
                    .ToListAsync();

                var lastSoundId = await ReadLastSoundTypeId(userId);


                //memory card
                var memoryCard = await _unitOfWork.MemoryCardStatisticsRepository
                    .Query(x => x.UserId == userId && x.Created.Date == today && x.IsPractice == false)
                    .FirstOrDefaultAsync();

                var lastPictureId = await ReadLastPictureTypeId(userId);

                var cardSize = await ReadCardSize(userId);

                var result = new DailyTrainingStatisticsResponse
                {
                    MemoryCard = _factory.Create(memoryCard),
                    MemorySound = _factory.Create(trainings.Where(x => x.TrainingMode == Entity.TrainingModeType.MemorySound).FirstOrDefault()),
                    WhatDayIsIt = _factory.Create(trainings.Where(x => x.TrainingMode == Entity.TrainingModeType.WhatDayIsIt).FirstOrDefault()),
                    MemoryNumber = _factory.Create(trainings.Where(x => x.TrainingMode == Entity.TrainingModeType.MemoryNumber).FirstOrDefault()),
                    Math = _factory.Create(trainings.Where(x => x.TrainingMode == Entity.TrainingModeType.Math).FirstOrDefault()),
                    MemoryMatrix = _factory.Create(trainings.Where(x => x.TrainingMode == Entity.TrainingModeType.MemoryMatrix).FirstOrDefault()),
                    BestMemorySoundScore = await ReadBestScore(userId, Entity.TrainingModeType.MemorySound),
                    BestWhatDayIsItScore = await ReadBestScore(userId, Entity.TrainingModeType.WhatDayIsIt),
                    BestMemoryNumberScore = await ReadBestScore(userId, Entity.TrainingModeType.MemoryNumber),
                    BestMathdScore = await ReadBestScore(userId, Entity.TrainingModeType.Math),
                    BestMemoryMatrixScore = await ReadBestScore(userId, Entity.TrainingModeType.MemoryMatrix),
                    LastPictureTypeId = lastPictureId,
                    LastSoundTypeId = lastSoundId,
                    MemoryCardSizeType = cardSize
                };

                return await Task.FromResult(new ReadDailyTrainingStatisticsResponse
                {
                    StatusCode = StatusCode.Ok,
                    Result = result
                });
            }
            catch (Exception ex)
            {
                return await _validator.CreateServerErrorResponse<ReadDailyTrainingStatisticsResponse>(ex.Message);
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

        /// <summary>
        /// read best score by training mode
        /// </summary>
        private async Task<long> ReadBestScore(long userId, Entity.TrainingModeType trainingMode)
        {
            return await _unitOfWork.TrainingStatisticsRepository
                  .Query(x => x.UserId == userId && x.TrainingMode == trainingMode)
                  .OrderByDescending(x => x.Score)
                  .Select(x => x.Score)
                  .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Read last sound type id
        /// </summary>
        private async Task<int> ReadLastSoundTypeId(long userId)
        {
            int result = 0;

            try
            {
                var trainings = await _unitOfWork.TrainingStatisticsRepository
                      .Query(x => x.UserId == userId && x.TrainingMode == Entity.TrainingModeType.MemorySound)
                      .OrderByDescending(x => x.Created)
                      .Take(2)
                      .ToListAsync();

                if (trainings.Any())
                {
                    var first = trainings.FirstOrDefault();
                    if (first.Created.Date == DateTime.UtcNow.Date)
                    {
                        if (trainings.Count > 1)
                        {
                            return trainings.LastOrDefault().SoundTypeId;
                        }
                    }
                    else
                    {
                        return trainings.FirstOrDefault().SoundTypeId;
                    }
                }
                else
                {
                    return 1;
                }

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        /// <summary>
        /// Calculate card size
        /// </summary>
        private async Task<MemoryCardSizeType> ReadCardSize(long userId)
        {
            var cards = await _unitOfWork.MemoryCardStatisticsRepository
                   .Query(x => x.UserId == userId && x.IsPractice == false)
                   .OrderByDescending(x => x.Created)
                   .ToListAsync();

            if (!cards.Any())
                return MemoryCardSizeType.Small;

            if (cards.Count == 1)
                return MemoryCardSizeType.Medium;

            if (cards.Count >= 2)
                return MemoryCardSizeType.Large;

            return MemoryCardSizeType.Large;
        }
        /// <summary>
        /// Read last picture type id
        /// </summary>
        private async Task<int> ReadLastPictureTypeId(long userId)
        {
            int result = 0;

            try
            {

                var cards = await _unitOfWork.MemoryCardStatisticsRepository
                      .Query(x => x.UserId == userId && x.IsPractice == false)
                      .OrderByDescending(x => x.Created)
                      .Take(2)
                      .ToListAsync();

                if (cards.Any())
                {
                    var first = cards.FirstOrDefault();
                    if (first.Created.Date == DateTime.UtcNow.Date)
                    {
                        if (cards.Count > 1)
                        {
                            return cards.LastOrDefault().PictureTypeId;
                        }
                    }
                    else
                    {
                        return cards.FirstOrDefault().PictureTypeId;
                    }
                }
                else
                {
                    return 1;
                }

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
