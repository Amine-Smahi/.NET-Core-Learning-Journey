using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.Property(l => l.Titulo)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(l => l.Assunto)
                    .HasMaxLength(600);

            builder.Property(l => l.ISBN)
                    .HasMaxLength(15);
        }
    }
}
