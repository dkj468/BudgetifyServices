using IdentityService.Entities;

namespace IdentityService.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(int id);
        public Task<User> CreateUser(User user);
        public Task<User> GetUserByEmail(string email);


    }
}
