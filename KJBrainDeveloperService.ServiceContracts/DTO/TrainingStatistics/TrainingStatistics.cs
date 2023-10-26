namespace KJBrainDeveloperService.ServiceContracts
{

    /// <summary>
    /// Training statistics object for client
    /// </summary>
    public class TrainingStatistics
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// User id for statistics
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Score
        /// </summary>
        public long Score { get; set; }
        /// <summary>
        /// Training mode type
        /// </summary>
        public TrainingModeType TrainingMode { get; set; }
        /// <summary>
        /// created date
        /// </summary
        public DateTime Created { get; set; }
    }
}
