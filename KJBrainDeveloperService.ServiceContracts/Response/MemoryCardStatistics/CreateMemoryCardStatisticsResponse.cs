namespace KJBrainDeveloperService.ServiceContracts
{

    /// <summary>
    /// Create memory card statistics response
    /// </summary>
    public class CreateMemoryCardStatisticsResponse : ResponseBase
    {
        public MemoryCardStatistics Result { get; set; }
    }
}
