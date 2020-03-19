using Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Banking.Application.Models;

namespace Banking.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task Transfer(AccountTransfer transfer);
    }
}
