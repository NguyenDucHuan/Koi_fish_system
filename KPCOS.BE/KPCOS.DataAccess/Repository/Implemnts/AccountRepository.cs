using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class AccountRepository : IAccountRepository
    {
        public Task<Account> AddAccountAsync(Account Account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> DeleteAccountAsync(Account Account)
        {
            throw new NotImplementedException();
        }
        public Task<Account> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAllAccountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account> UpdateAccountAsync(Account Account)
        {
            throw new NotImplementedException();
        }
    }
}
