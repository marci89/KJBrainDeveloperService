namespace KJBrainDeveloperService.Persistence.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// User's identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// User's hashed password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User language
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// User avatar Id
        /// </summary>
        public int AvatarId { get; set; }

        /// <summary>
        /// User created date
        /// </summary>
        public DateTime Created { get; set; }


        /// <summary>
        /// Reset token for reseting password
        /// </summary>
        public string ResetToken { get; set; }

        /// <summary>
        /// Reset token expiration time for reseting password
        /// </summary>
        public DateTime? ResetTokenExpiration { get; set; }

        #region Navigation propeties

        /// <summary>
        /// User's TrainingStatistics
        /// </summary>
        public ICollection<TrainingStatistics> TrainingStatistics { get; set; }

        /// <summary>
        /// User's MemoryCardStatistics
        public ICollection<MemoryCardStatistics> MemoryCardStatistics { get; set; }

        #endregion

    }
}

