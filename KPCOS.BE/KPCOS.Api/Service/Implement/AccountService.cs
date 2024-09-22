﻿using System.IdentityModel.Tokens.Jwt;
using System.Text;
using KPCOS.Api.Constants;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;

namespace KPCOS.Api.Service.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAccountById(int id)
        {
            var account = await _accountRepository.GetAccountAsync(id);
            if (account == null)
            {
                throw new NotFoundException($"Account with id {id} not found");
            }
            return account;
        }
    }
}


