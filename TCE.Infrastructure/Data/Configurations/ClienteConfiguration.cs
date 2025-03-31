using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Domain.Entities;

namespace TCE.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Telefone)
                .HasMaxLength(20);

            builder.Property(c => c.DataCadastro)
                .IsRequired();

            builder.HasMany(c => c.Compras)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
