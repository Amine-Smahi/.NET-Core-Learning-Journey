using System;
using System.Collections.Generic;
using System.Text;
using Domain.Events;

namespace Domain.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; protected set; }

        protected Command()
        {
            this.TimeStamp = DateTime.Now;
        }
    }
}
