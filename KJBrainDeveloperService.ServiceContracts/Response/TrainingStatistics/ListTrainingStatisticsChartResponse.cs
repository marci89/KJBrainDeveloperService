namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// List training statistics datas for chart diagram response
    /// </summary>
    public class ListTrainingStatisticsChartResponse : ResponseBase
    {
        public TrainingStatisticsChartResult Result { get; set; }
    }
}
