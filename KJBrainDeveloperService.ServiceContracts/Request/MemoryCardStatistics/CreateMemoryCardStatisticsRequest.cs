namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// Create memory card statistics request by logined user id
    /// </summary>
    public class CreateMemoryCardStatisticsRequest
    {
        /// <summary>
        /// Moved number
        /// </summary>
        public long Moved { get; set; }
        /// <summary>
        /// (easy, mediu, hard, nightmare)
        /// </summary>
        public DifficultType Difficult { get; set; }
        /// <summary>
        /// Last picture type id to be diverse.
        /// </summary>
        public int LastPictureTypeId { get; set; }
    }
}
