namespace KJBrainDeveloperService.Persistence.Entities
{
    /// <summary>
    /// Training statistics entity
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
        /// Sound type id to be diverse.
        /// </summary>
        public int SoundTypeId { get; set; }
        /// <summary>
        /// created date
        /// </summary
        public DateTime Created { get; set; }

        #region Navigation propeties

        /// <summary>
        /// statistics's User
        /// </summary>
        public virtual User User { get; set; }

        #endregion
    }
}
