using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BOL.Entity;

namespace DAL.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.HasKey(c => c.Id);

            builder.HasAlternateKey(c => c.CPF);

            builder.Property(c => c.DataCadastro)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.RendaFamiliar)
               .IsRequired();


        }
    }
}
