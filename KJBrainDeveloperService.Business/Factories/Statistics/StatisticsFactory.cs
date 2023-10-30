

using KJBrainDeveloperService.ServiceContracts;
using Entity = KJBrainDeveloperService.Persistence.Entities;

namespace KJBrainDeveloperService.Business
{

    /// <summary>
    /// Statistics object mapping
    /// </summary>
    public class StatisticsFactory
    {

        #region TrainingStatistics

        /// <summary>
        /// Map client TrainingStatistics from domain TrainingStatistics
        /// </summary>
        public TrainingStatistics Create(Entity.TrainingStatistics request)
        {
            if (request is null)
                return null;

            return new TrainingStatistics
            {
                Id = request.Id,
                UserId = request.UserId,
                Score = request.Score,
                SoundTypeId = request.SoundTypeId,
                TrainingMode = Create(request.TrainingMode),
                Created = request.Created,
            };
        }

        /// <summary>
        /// Map domain TrainingStatistics from client TrainingStatistics
        /// </summary>
        public Entity.TrainingStatistics Create(CreateTrainingStatisticsRequest request, long userId)
        {
            if (request is null)
                return null;

            return new Entity.TrainingStatistics
            {
                UserId = userId,
                Score = request.Score,
                SoundTypeId = request.SoundTypeId,
                TrainingMode = Create(request.TrainingMode),
                Created = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Create a TrainingStatisticsChartResult object
        /// </summary>
        public TrainingStatisticsChartResult Create(List<Entity.TrainingStatistics> entites, int quantity)
        {
            if (entites is null)
                return null;

            List<string> label = Enumerable.Range(1, quantity).Select(i => i.ToString()).ToList();

            return new TrainingStatisticsChartResult
            {
                ChartLabel = label,
                MemorySoundChartData = Create(entites, quantity, Entity.TrainingModeType.MemorySound),
                MemoryNumberChartData = Create(entites, quantity, Entity.TrainingModeType.MemoryNumber),
                MemoryMatrixChartData = Create(entites, quantity, Entity.TrainingModeType.MemoryMatrix),
                MathChartData = Create(entites, quantity, Entity.TrainingModeType.Math)
            };
        }


        /// <summary>
        /// Create a TrainingStatistics ChartData
        /// </summary>
        private List<string> Create(List<Entity.TrainingStatistics> entites, int quantity, Entity.TrainingModeType type)
        {
            var data = entites.Where(x => x.TrainingMode == type).OrderByDescending(x => x.Created).Take(quantity).Select(x => x.Score.ToString()).ToList();
            data.Reverse();
            return data;
        }

        /// <summary>
        /// Map client TrainingModeType from domain TrainingModeType
        /// </summary>
        public TrainingModeType Create(Entity.TrainingModeType type)
        {
            switch (type)
            {
                case Entity.TrainingModeType.MemorySound:
                    return TrainingModeType.MemorySound;
                case Entity.TrainingModeType.MemoryNumber:
                    return TrainingModeType.MemoryNumber;
                case Entity.TrainingModeType.MemoryMatrix:
                    return TrainingModeType.MemoryMatrix;
                case Entity.TrainingModeType.Math:
                    return TrainingModeType.Math;
                case Entity.TrainingModeType.WhatDayIsIt:
                    return TrainingModeType.WhatDayIsIt;
                default:
                    throw new ArgumentException("Invalid TrainingModeType.");
            }
        }

        /// <summary>
        /// Map domain TrainingModeType from client TrainingModeType
        /// </summary>
        public Entity.TrainingModeType Create(TrainingModeType type)
        {
            switch (type)
            {
                case TrainingModeType.MemorySound:
                    return Entity.TrainingModeType.MemorySound;
                case TrainingModeType.MemoryNumber:
                    return Entity.TrainingModeType.MemoryNumber;
                case TrainingModeType.MemoryMatrix:
                    return Entity.TrainingModeType.MemoryMatrix;
                case TrainingModeType.Math:
                    return Entity.TrainingModeType.Math;
                case TrainingModeType.WhatDayIsIt:
                    return Entity.TrainingModeType.WhatDayIsIt;
                default:
                    throw new ArgumentException("Invalid TrainingModeType.");
            }
        }

        #endregion


        #region MemoryCardStatistics

        /// <summary>
        /// Map client MemoryCardStatistics from domain MemoryCardStatistics
        /// </summary>
        public MemoryCardStatistics Create(Entity.MemoryCardStatistics request)
        {
            if (request is null)
                return null;

            return new MemoryCardStatistics
            {
                Id = request.Id,
                UserId = request.UserId,
                Moved = request.Moved,
                Difficult = Create(request.Difficult),
                PictureTypeId = request.PictureTypeId,
                IsPractice = request.IsPractice,
                Created = request.Created,
            };
        }

        /// <summary>
        /// Map domain MemoryCardStatistics from client MemoryCardStatistics
        /// </summary>
        public Entity.MemoryCardStatistics Create(CreateMemoryCardStatisticsRequest request, long userId)
        {
            if (request is null)
                return null;

            return new Entity.MemoryCardStatistics
            {
                UserId = userId,
                Moved = request.Moved,
                Difficult = Create(request.Difficult),
                PictureTypeId = request.PictureTypeId,
                IsPractice = request.IsPractice,
                Created = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Create a MemoryCardStatisticsChartResult object
        /// </summary>
        public MemoryCardStatisticsChartResult Create(List<Entity.MemoryCardStatistics> entites, int quantity)
        {
            if (entites is null)
                return null;

            List<string> label = Enumerable.Range(1, quantity).Select(i => i.ToString()).ToList();

            return new MemoryCardStatisticsChartResult
            {
                ChartLabel = label,
                EasyChartData = Create(entites, quantity, Entity.DifficultType.Easy),
                MediumChartData = Create(entites, quantity, Entity.DifficultType.Medium),
                HardChartData = Create(entites, quantity, Entity.DifficultType.Hard),
                NightmareChartData = Create(entites, quantity, Entity.DifficultType.Nightmare)
            };
        }


        /// <summary>
        /// Create a MemoryCardStatistics ChartData
        /// </summary>
        private List<string> Create(List<Entity.MemoryCardStatistics> entites, int quantity, Entity.DifficultType type)
        {
            var data = entites.Where(x => x.Difficult == type).OrderByDescending(x => x.Created).Take(quantity).Select(x => x.Moved.ToString()).ToList();
            data.Reverse();
            return data;
        }

        /// <summary>
        /// Map client DifficultType from domain DifficultType
        /// </summary>
        private DifficultType Create(Entity.DifficultType type)
        {
            switch (type)
            {
                case Entity.DifficultType.Easy:
                    return DifficultType.Easy;
                case Entity.DifficultType.Medium:
                    return DifficultType.Medium;
                case Entity.DifficultType.Hard:
                    return DifficultType.Hard;
                case Entity.DifficultType.Nightmare:
                    return DifficultType.Nightmare;
                default:
                    throw new ArgumentException("Invalid DifficultType.");
            }
        }

        /// <summary>
        /// Map domain DifficultType from client DifficultType
        /// </summary>
        private Entity.DifficultType Create(DifficultType type)
        {
            switch (type)
            {
                case DifficultType.Easy:
                    return Entity.DifficultType.Easy;
                case DifficultType.Medium:
                    return Entity.DifficultType.Medium;
                case DifficultType.Hard:
                    return Entity.DifficultType.Hard;
                case DifficultType.Nightmare:
                    return Entity.DifficultType.Nightmare;
                default:
                    throw new ArgumentException("Invalid DifficultType.");
            }
        }

        #endregion
    }
}


