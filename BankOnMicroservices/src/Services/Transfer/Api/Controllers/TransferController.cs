using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfer.Application.Interfaces;
using Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Transfer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            var transfers = _transferService.GetTransferLogs();
            return Ok(transfers);
        }
    }
}
