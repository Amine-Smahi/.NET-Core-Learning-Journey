using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain.Models;

namespace Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAll();
    }
}
