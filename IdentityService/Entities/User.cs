namespace IdentityService.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
