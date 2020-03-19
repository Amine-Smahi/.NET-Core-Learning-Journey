using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> Get()
        {
            return Ok(await _accountService.GetAccounts());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Account>>> Post([FromBody] AccountTransfer accountTransfer)
        {
            await _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
