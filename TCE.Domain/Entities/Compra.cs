using TCE.Domain.Common;

namespace TCE.Domain.Entities
{
    public class Compra : BaseEntity
    {
        private Compra() { }

        public Compra(string descricao, decimal valorCompra, Guid idempotencyKey)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição da compra é obrigatória.", nameof(descricao));

            DataCompra = DateTime.UtcNow;
            Descricao = descricao;
            ValorCompra = valorCompra;
            IdempotencyKey = idempotencyKey;
        }

        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; } = null!;
        public DateTime DataCompra { get; private set; }
        public string Descricao { get; private set; }
        public bool Pago { get; private set; }
        public decimal? ValorPago { get; private set; }
        public decimal ValorCompra { get; set; }
        public DateTime? DataPagamento { get; private set; }
        public Guid IdempotencyKey { get; private set; }

        public decimal Pagar(decimal valorPago)
        {
            if (valorPago <= 0)
                throw new ArgumentException("O valor pago deve ser maior que zero.", nameof(valorPago));

            if (Pago)
                throw new InvalidOperationException("Compra já foi paga.");

            var totalPago = (ValorPago ?? 0) + valorPago;
            var troco = Math.Max(totalPago - ValorCompra, 0);

            ValorPago = totalPago;

            if (totalPago >= ValorCompra)
            {
                Pago = true;
                DataPagamento = DateTime.UtcNow;

                ValorPago = ValorCompra;
            }

            return troco;
        }
    }
}
