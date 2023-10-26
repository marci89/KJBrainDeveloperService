namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// List memory card statistics datas for chart diagram response
    /// </summary>
    public class ListMemoryCardStatisticsChartResponse : ResponseBase
    {
        public MemoryCardStatisticsChartResult Result { get; set; }
    }
}
