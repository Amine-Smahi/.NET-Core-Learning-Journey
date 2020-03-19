using Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transfer.Infrastructure.Data
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
