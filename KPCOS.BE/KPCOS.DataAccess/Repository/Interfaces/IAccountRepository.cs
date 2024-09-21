using KPOCOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAllAccountAsync();
        public Task<Account> GetAccountAsync(int id);
        public Task<Account> GetByUsernameAsync(string username);
        public Task<Account> AddAccountAsync(Account Account);
        public Task<Account> DeleteAccountAsync(Account Account);
        public Task<Account> UpdateAccountAsync(Account Account);
    }
}
