﻿using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly KpcosdbContext _context;

        public AccountRepository(KpcosdbContext kpcosdbContext)
        {
            _context = kpcosdbContext;
        }

        public async Task<Account> AddAccountAsync(Account account)
        {
            var checkDuplicate = await _context.Accounts.FindAsync(account.UserName);
            if (checkDuplicate != null)
                throw new Exception("Account already exists");
            _context.Accounts.Add(account);
            return account;
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            var checkExist = await _context.Accounts.FindAsync(accountId);
            if (checkExist == null)
            {
                throw new Exception("Account not found");
            }
            _context.Accounts.Remove(checkExist);
            SaveChange("OK");
        }

        public async Task<Account> GetAccountAsync(int accountId)
        {
            var account = await _context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.Id == accountId);
            if (account == null)
            {
                return null;
            }
            return account;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var accounts = await _context.Accounts.ToListAsync();
            if (accounts == null)
            {
                return null;
            }
            return accounts;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            var checkExist = await _context.Accounts.FindAsync(account.Id);
            if (checkExist == null)
            {
                throw new Exception("Account not found");
            }
            _context.Update(account);
            return account;
        }
        public T SaveChange<T>(T u)
        {
            _context.SaveChanges();
            return u;
        }

        public async Task<Account> GetByUserName(string userName)
        {
            var account = await _context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.UserName == userName);
            if (account == null)
            {
                return null;
            }
            return account;
        }
    }

}
