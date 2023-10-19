using KJBrainDeveloperService.ServiceContracts;
using Entity = KJBrainDeveloperService.Persistence.Entities;

namespace KJBrainDeveloperService.Business
{
    /// <summary>
    /// User object mapping
    /// </summary>
    public class UserFactory
    {
        private readonly PasswordSecurityHandler _passwordSecurityHandler;
        private readonly UserValidator _validator;
        private readonly IAuthTokenService _tokenService;

        public UserFactory(PasswordSecurityHandler passwordSecurityHandler, UserValidator validator, IAuthTokenService tokenService)
        {
            _passwordSecurityHandler = passwordSecurityHandler;
            _tokenService = tokenService;
            _validator = validator;
        }

        /// <summary>
        /// Map client user from domain user
        /// </summary>
        public User Create(Entity.User request)
        {
            if (request is null)
                return null;

            return new User
            {
                Id = request.Id,
                Username = request.Username,
                Email = request.Email,
                Language = request.Language,
                AvatarId = request.AvatarId,
                Created = request.Created,

            };
        }

        /// <summary>
        /// Map domain user from client user (registration)
        /// </summary>
        public Entity.User Create(CreateUserRequest request)
        {
            if (request is null)
                return null;

            return new Entity.User
            {
                Username = request.Username,
                Email = request.Email,
                Password = _passwordSecurityHandler.HashPassword(request.Password),
                Language = request.Language,
                AvatarId = request.AvatarId,
                Created = DateTime.UtcNow,
            };
        }

        /// <summary>
        /// Map login user object from domain user and login datas
        /// </summary>
        public LoginUser Create(LoginUserRequest request, Entity.User user)
        {
            if (request is null || user is null)
                return null;

            var passwordMatchValidation = _validator.IsValidPasswordMatch(user.Id, request.Password);
            if (passwordMatchValidation.HasError)
                return null;

            return new LoginUser
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Language = user.Language,
                AvatarId = user.AvatarId,
                Token = _tokenService.CreateToken(user)
            };
        }

        public string CreatePasswordHash(string password)
        {
            return _passwordSecurityHandler.HashPassword(password);
        }
    }
}
