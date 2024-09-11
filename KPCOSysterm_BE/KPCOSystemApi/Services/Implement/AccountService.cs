using KPCOSystem.DataAccess.Repository.Interfaces;
using KPCOSystemApi.Services.Interfaces;

namespace KPCOSystemApi.Services.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<bool> CheckLogin(string username, string password)
        {
            return Task.FromResult(true);
        }
    }
}
