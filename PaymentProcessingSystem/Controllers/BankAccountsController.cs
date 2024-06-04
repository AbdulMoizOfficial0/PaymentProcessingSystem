using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentProcessingSystem.DTOs;
using PaymentProcessingSystem.Models;
using PaymentProcessingSystem.Services;

namespace PaymentProcessingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly AccountService<BankAccount> _service;

        public BankAccountsController(AccountService<BankAccount> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccountDTO>>> GetAll()
        {
            var accounts = await _service.GetAllAccountsAsync();
            return Ok(accounts.Select(a=> new BankAccountDTO
            {
                id = a.Id,
                AccountNumber = a.AccountNumber,
                Balance = a.Balance
            }));
        }
        [HttpGet("id")]
        public async Task<ActionResult<BankAccountDTO>> GetById(int id)
        {
            var account = await _service.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(new BankAccountDTO
            {
                id = account.Id,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance
            });
        }
        [HttpPost]
        public async Task<ActionResult> Create(BankAccountDTO dto)
        {
            var account = new BankAccount
            {
                AccountNumber = dto.AccountNumber,
                Balance = dto.Balance
            };
            await _service.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = account.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BankAccountDTO dto)
        {
            var account = await _service.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            account.AccountNumber = dto.AccountNumber;
            account.Balance = dto.Balance;
            await _service.UpdateAccountAsync(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _service.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            await _service.DeleteAccountAsync(id);
            return NoContent();
        }
    }
}
