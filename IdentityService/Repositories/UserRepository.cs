using IdentityService.Data;
using IdentityService.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }
        public async Task<User> CreateUser(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            return user;
        }
    }
}
