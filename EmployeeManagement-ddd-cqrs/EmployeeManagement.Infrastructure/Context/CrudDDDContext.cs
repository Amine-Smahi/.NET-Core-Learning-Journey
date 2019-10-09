using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Infrastructure.Context
{
    public class CrudDDDContext : DbContext
    {
        public CrudDDDContext(DbContextOptions<CrudDDDContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(new EmployeeMap().Configure);
        }
    }
}
