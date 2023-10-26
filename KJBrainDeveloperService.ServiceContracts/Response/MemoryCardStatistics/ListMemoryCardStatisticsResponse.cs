namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// List memory card statistics response
    /// </summary>
    public class ListMemoryCardStatisticsResponse : ResponseBase
    {
        public List<MemoryCardStatistics> Result { get; set; }
    }
}
