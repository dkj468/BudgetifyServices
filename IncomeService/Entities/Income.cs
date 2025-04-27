namespace IncomeService.Entities
{
    public class Income : BaseEntity, ITenantEntity
    {
        public int IncomeTypeId { get; set; }
        public string? Description { get; set; }
        public Decimal Amount { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set;}
        public int AccountId { get; set; }       
        public IncomeType IncomeType { get; set; }
    }
}
