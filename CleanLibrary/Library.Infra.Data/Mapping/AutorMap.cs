using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Mapping
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");

            builder.Property(a => a.Nome)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(a => a.DataCadastro)
                    .IsRequired();

            builder.Property(a => a.Status)
                    .HasDefaultValue(true);
        }
    }
}
