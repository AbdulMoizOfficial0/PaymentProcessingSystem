namespace PaymentProcessingSystem.Models
{
    public abstract class Account
    {
        public int Id { get; set; }
        public required string AccountName {  get; set; }
        public decimal Balance { get; set; }

    }
}
