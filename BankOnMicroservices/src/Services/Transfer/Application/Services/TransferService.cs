using Domain.Bus;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Transfer.Application.Interfaces;

namespace Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;
        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetAll();
        }
    }
}
