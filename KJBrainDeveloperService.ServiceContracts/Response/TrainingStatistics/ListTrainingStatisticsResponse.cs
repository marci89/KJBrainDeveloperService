namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// List training statistics response
    /// </summary>
    public class ListTrainingStatisticsResponse : ResponseBase
    {
        public List<TrainingStatistics> Result { get; set; }
    }
}
