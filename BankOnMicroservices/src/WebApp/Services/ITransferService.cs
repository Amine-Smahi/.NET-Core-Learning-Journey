using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.DTO;

namespace WebApp.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }
}
