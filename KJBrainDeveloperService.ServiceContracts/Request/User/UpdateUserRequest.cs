namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// Update user request
    /// </summary>
    public class UpdateUserRequest
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// User language
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// User avatar Id
        /// </summary>
        public int AvatarId { get; set; }
    }
}
