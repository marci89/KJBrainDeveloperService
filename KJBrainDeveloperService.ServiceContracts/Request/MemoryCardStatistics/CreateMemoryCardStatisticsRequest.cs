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
        /// Picture type id to be diverse.
        /// </summary>
        public int PictureTypeId { get; set; }
        /// <summary>
        /// practice mode or training
        /// </summary>
        public bool IsPractice { get; set; }
    }
}
