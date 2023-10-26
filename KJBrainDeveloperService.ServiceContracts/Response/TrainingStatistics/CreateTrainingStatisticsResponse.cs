namespace KJBrainDeveloperService.ServiceContracts
{

    /// <summary>
    /// Create training statistics response
    /// </summary>
    public class CreateTrainingStatisticsResponse : ResponseBase
    {
        public TrainingStatistics Result { get; set; }
    }
}
