namespace IdentityService.Services
{
    public interface IAuthService
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string password, string hashedPassword);
    }
}
