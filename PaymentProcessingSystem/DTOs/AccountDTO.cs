namespace PaymentProcessingSystem.DTOs
{
    public abstract class AccountDTO
    {
        public int id {  get; set; }
        public required string AccountName { get; set; }
        public decimal Balance { get; set; }

    }
}
