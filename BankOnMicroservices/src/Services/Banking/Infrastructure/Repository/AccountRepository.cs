using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Banking.Infrastructure.Data;

namespace Banking.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;
        public AccountRepository(BankingDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Accounts.ToListAsync();
        }
    }
}
