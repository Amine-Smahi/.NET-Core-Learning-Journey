using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Mapping
{
    public class EditorMap : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder.ToTable("Editors");

            builder.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(e => e.DataCadastro)
                    .IsRequired();

            builder.Property(e => e.Status)
                    .HasDefaultValue(true);
        }
    }
}
