namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// MemoryCard statistics object for client
    /// </summary>
    public class MemoryCardStatistics
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
        /// <summary>
        /// created date
        /// </summary
        public DateTime Created { get; set; }
    }
}
