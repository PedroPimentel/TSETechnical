using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TCE.Domain.Entities;

namespace TCE.Infrastructure.Data.Configurations
{
    public class CompraConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.ValorDevido)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Pago)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(c => c.DataCompra).IsRequired();

            builder.Property(c => c.ValorPago)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.DataPagamento);

            builder.Property(c => c.IdempotencyKey).IsRequired();

            builder.HasIndex(c => c.IdempotencyKey).IsUnique();
        }
    }
}
