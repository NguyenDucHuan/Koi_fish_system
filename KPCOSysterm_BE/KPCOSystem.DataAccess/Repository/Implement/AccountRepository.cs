using Domain.Data;
using Domain.Models;
using KPCOSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPCOSystem.DataAccess.Repository.Implement
{
    public class AccountRepository : IAccountRepository
    {
        private readonly KoiPondDbContext _context;

        public AccountRepository(KoiPondDbContext koiPondDbContext)
        {
            _context = koiPondDbContext;
        }

        public async Task<bool> AddAccountAsync(Account account)
        {
            var check = await _context.Accounts.FirstOrDefaultAsync(c => c.UserName == account.UserName);
            if (check == null)
            {
                return false;
            }
            _context.Accounts.Add(account);
            await SavechangesAsync();
            return true;

        }
        public async Task<bool> DeleteAccountAsync(int accountId)
        {
            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null)
            {
                return false;
            }
            _context.Accounts.Remove(account);
            await SavechangesAsync();
            return true;
        }

        public async Task<Account> GetAccountAsync(int accountId)
        {
            var account = await _context.Accounts
                    .Include(a => a.DiscountPounds)
                    .Include(a => a.Orders)
                    .Include(a => a.Ponds)
                    .Include(a => a.Ratings)
                    .Include(a => a.Role)
                    .Include(a => a.User)
                    .FirstOrDefaultAsync(a => a.Id == accountId);
            if (account == null)
            {
                return null;
            }
            return account;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var accountList = await _context.Accounts
                    .Include(a => a.DiscountPounds)
                    .Include(a => a.Orders)
                    .Include(a => a.Ponds)
                    .Include(a => a.Ratings)
                    .Include(a => a.Role)
                    .Include(a => a.User)
                    .ToListAsync();
            if (accountList == null)
            {
                return null;
            }
            return accountList;
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await SavechangesAsync();
            return true;
        }
        private async Task SavechangesAsync() => await _context.SaveChangesAsync();
    }
}
