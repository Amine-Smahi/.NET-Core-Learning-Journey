using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Transfer.Infrastructure.Data;

namespace Transfer.Infrastructure.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _dbContext;
        public TransferRepository(TransferDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<TransferLog> GetAll()
        {
            return _dbContext.TransferLogs;
        }

        public void Add(TransferLog transfer)
        {
            _dbContext.TransferLogs.Add(transfer);
            _dbContext.SaveChanges();
        }
    }
}
