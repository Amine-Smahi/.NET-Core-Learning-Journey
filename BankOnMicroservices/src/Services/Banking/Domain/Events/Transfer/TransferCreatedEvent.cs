using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Domain.Events.Transfer
{
    public class TransferCreatedEvent : Event
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public decimal Amount { get; set; }

        public TransferCreatedEvent(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
