namespace ExpenseService.Entities
{
    public interface ITenantEntity
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
