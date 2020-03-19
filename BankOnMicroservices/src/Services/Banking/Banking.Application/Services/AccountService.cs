using Domain.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Commands.Transfer;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;

namespace Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;
        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            this._accountRepository = accountRepository;
            this._bus = bus;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _accountRepository.GetAll();
        }

        public async Task Transfer(AccountTransfer transfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                transfer.FromAccount,
                transfer.ToAccount,
                transfer.Amount
                );

            await _bus.SendCommand(createTransferCommand);
        }
    }
}
