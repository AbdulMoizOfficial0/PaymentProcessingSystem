using Microsoft.EntityFrameworkCore;
using PaymentProcessingSystem.Models;

namespace PaymentProcessingSystem.Data
{
    public class PaymentProcessingContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCardAccount> CreditCards { get; set;}
        public DbSet<DigitalWallet> DigitalWallets { get; set;}

        public PaymentProcessingContext(DbContextOptions<PaymentProcessingContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
