using PaymentProcessingSystem.Repositories;

namespace PaymentProcessingSystem.Services
{
    public class AccountService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public AccountService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<T>> GetAllAccountsAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<T> GetAccountByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task AddAccountAsync(T account)
        {
            await _repository.AddAsync(account);
            await _repository.SaveAsync();
        }
        public async Task UpdateAccountAsync(T account)
    {
        _repository.Update(account);
        await _repository.SaveAsync();
    }

    public async Task DeleteAccountAsync(int id)
    {
        var account = await _repository.GetByIdAsync(id);
        if (account != null)
        {
            _repository.Delete(account);
            await _repository.SaveAsync();
        }
    }
    }
}
