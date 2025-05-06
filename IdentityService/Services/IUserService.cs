using IdentityService.DTOs;

namespace IdentityService.Services
{
    public interface IUserService
    {
        public Task<UserDto> CreateUser(CreateUserDto user);
        public Task<LoggedInUserDto> LoginUser (LoginDto login);
        public Task<LoggedInUserDto> RegisterUser (RegisterUserDto user);

    }
}
