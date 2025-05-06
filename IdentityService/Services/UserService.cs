using IdentityService.DTOs;
using IdentityService.Entities;
using IdentityService.Repositories;

namespace IdentityService.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IAuthService authService, IUserRepository userRepository, ITokenService tokenService)
        {
            _authService = authService;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<UserDto> CreateUser(CreateUserDto user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                ImageUrl = user.ImageUrl,
                IsEmailConfirmed = false,
                Password = _authService.HashPassword(user.Password)
            };
            var userFromDB = await _userRepository.CreateUser(newUser);
            var createdUser = new UserDto
            {
                Id = userFromDB.Id,
                Name = userFromDB.Name,
                Email = userFromDB.Email,
                ImageUrl = userFromDB.ImageUrl,
                IsEmailConfirmed = userFromDB.IsEmailConfirmed
            };

            return createdUser;
        }

        public async Task<LoggedInUserDto> LoginUser(LoginDto login)
        {
            // get user from DB
            var user = await _userRepository.GetUserByEmail(login.Email);
            if (user == null) 
            {
                throw new Exception("No user found with given email id, please provide a valid email");
            }
            // verify password 
            var isPasswordVerified = _authService.VerifyPassword(login.Password, user.Password);
            if (!isPasswordVerified) 
            {
                throw new Exception("Invalid password, please provide a valid password");
            }

            return new LoggedInUserDto
            {
                Name = user.Name,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<LoggedInUserDto> RegisterUser (RegisterUserDto user)
        {
            // get user from DB
            var userFromDB = await _userRepository.GetUserByEmail (user.Email);
            if (userFromDB != null)
            {
                throw new Exception("user with this email id already exists");
            }

            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = _authService.HashPassword(user.Password),
                IsEmailConfirmed = false,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                ImageUrl = user.ImageUrl,
                IsDeleted = false
            };
            var createdUser = await _userRepository.CreateUser(newUser);

            return new LoggedInUserDto
            {
                Name = createdUser.Name,
                Email = createdUser.Email,
                Token = _tokenService.CreateToken (createdUser)
            };
        }
    }
}
