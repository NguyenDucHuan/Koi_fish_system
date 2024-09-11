using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPCOSystem.DataAccess.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(int accountId);
        Task<bool> AddAccountAsync(Account account);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> DeleteAccountAsync(int accountId);
    }
}
