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
        /// Picture type id to be diverse.
        /// </summary>
        public int PictureTypeId { get; set; }
        /// <summary>
        /// practice mode or training
        /// </summary>
        public bool IsPractice { get; set; }
        /// <summary>
        /// created date
        /// </summary
        public DateTime Created { get; set; }
    }
}
