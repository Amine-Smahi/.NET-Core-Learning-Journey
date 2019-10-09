using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Mapping
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FirstName");

            builder.Property(c => c.LastName)
                 .IsRequired()
                 .HasColumnName("LastName");

            builder.Property(c => c.Address)
                .IsRequired()
                .HasColumnName("Address");

            builder.Property(c => c.PersonalNumber)
                .IsRequired()
                .HasColumnName("PersonalNumber");

        }
    }
}
