namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// User object for client
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
    }
}
