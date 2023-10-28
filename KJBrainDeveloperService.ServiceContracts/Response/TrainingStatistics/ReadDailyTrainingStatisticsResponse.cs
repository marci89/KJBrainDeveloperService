namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// List training statistics datas for chart diagram response
    /// </summary>
    public class ReadDailyTrainingStatisticsResponse : ResponseBase
    {
        public DailyTrainingStatisticsResponse Result { get; set; }
    }
}