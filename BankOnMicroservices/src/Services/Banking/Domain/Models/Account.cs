using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
