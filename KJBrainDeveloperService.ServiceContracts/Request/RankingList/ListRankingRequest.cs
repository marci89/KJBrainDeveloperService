namespace KJBrainDeveloperService.ServiceContracts.Request.RankingList
{
    /// <summary>
    /// List top user's score by TrainingModeType request
    /// </summary>
    public class ListRankingRequest
    {
        /// <summary>
        /// TrainingModeType
        /// </summary>
        public TrainingModeType TrainingModeType { get; set; }
    }
}
