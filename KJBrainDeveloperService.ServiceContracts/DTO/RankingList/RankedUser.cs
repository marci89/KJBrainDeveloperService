namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// User with best score
    /// </summary>
    public class RankedUser
    {
        /// <summary>
        /// User's identifier
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// User avatar Id
        /// </summary>
        public int AvatarId { get; set; }
        /// <summary>
        /// TrainingModeType
        /// </summary>
        public TrainingModeType TrainingModeType { get; set; }

        /// <summary>
        /// User's score
        /// </summary>
        public long Score { get; set; }
    }
}
