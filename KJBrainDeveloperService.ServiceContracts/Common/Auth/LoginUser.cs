namespace KJBrainDeveloperService.ServiceContracts
{
    /// <summary>
    /// Login user object for client
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Email
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
        /// Auth token
        /// </summary>
        public string Token { get; set; }
    }
}
