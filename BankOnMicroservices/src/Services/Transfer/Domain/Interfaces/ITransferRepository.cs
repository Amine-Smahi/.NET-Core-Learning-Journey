using System;
using System.Collections.Generic;
using System.Text;
using Transfer.Domain.Models;

namespace Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        void Add(TransferLog transfer);
        IEnumerable<TransferLog> GetAll();
    }
}
