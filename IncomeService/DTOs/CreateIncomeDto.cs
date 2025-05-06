namespace IncomeService.DTOs
{
    public class CreateIncomeDto
    {
        public int AccountId { get; set; }
        public int IncomeTypeId {  get; set; }
        public string Description { get; set; }
        public Decimal Amount { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

    }
}
