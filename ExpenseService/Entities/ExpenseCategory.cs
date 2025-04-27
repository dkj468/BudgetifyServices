namespace ExpenseService.Entities
{
    public class ExpenseCategory : BaseEntity,ITenantEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
