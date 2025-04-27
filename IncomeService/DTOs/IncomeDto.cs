namespace IncomeService.DTOs
{
    public class IncomeDto
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public int IncomeTypeId { get; set; }
        public Decimal Amount { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int AccountId { get; set; }
        public string IncomeType { get; set; }
    }
}
