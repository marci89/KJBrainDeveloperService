namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// List top user's score by TrainingModeType response
    /// </summary>
    public class ListRankingResponse : ResponseBase
    {
        public List<RankedUser> Result { get; set; }
    }
}