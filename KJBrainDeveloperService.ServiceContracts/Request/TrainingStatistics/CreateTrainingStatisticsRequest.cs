namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// Create learn statistics request by logined user id
    /// </summary>
    public class CreateTrainingStatisticsRequest
    {
        /// <summary>
        /// Score
        /// </summary>
        public long Score { get; set; }
        /// <summary>
        /// Training mode type
        /// </summary>
        public TrainingModeType TrainingMode { get; set; }
        /// <summary>
        /// Sound type id to be diverse.
        /// </summary>
        public int SoundTypeId { get; set; }
    }
}
