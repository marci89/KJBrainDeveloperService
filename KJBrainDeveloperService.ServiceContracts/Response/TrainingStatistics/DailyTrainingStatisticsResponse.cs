namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// Daily training statistics response
    /// </summary>
    public class DailyTrainingStatisticsResponse
    {
        public MemoryCardStatistics MemoryCard { get; set; }
        public TrainingStatistics MemorySound { get; set; }
        public TrainingStatistics WhatDayIsIt { get; set; }
        public TrainingStatistics MemoryNumber { get; set; }
        public TrainingStatistics Math { get; set; }
        public TrainingStatistics MemoryMatrix { get; set; }

        public long BestMemorySoundScore { get; set; }
        public long BestWhatDayIsItScore { get; set; }
        public long BestMemoryNumberScore { get; set; }
        public long BestMathScore { get; set; }
        public long BestMemoryMatrixScore { get; set; }

        /// <summary>
        /// Last picture type id to be diverse.
        /// </summary>
        public int LastPictureTypeId { get; set; }
        /// <summary>
        /// Last sound type id to be diverse.
        /// </summary>
        public int LastSoundTypeId { get; set; }
        /// <summary>
        /// card size type
        /// </summary>
        public MemoryCardSizeType MemoryCardSizeType { get; set; }

    }
}
