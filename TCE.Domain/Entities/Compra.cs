using TCE.Domain.Common;

namespace TCE.Domain.Entities
{
    public class Compra : BaseEntity
    {
        private Compra() { }
        public Compra(string? descricao, decimal valorDevido, Guid idempotencyKey)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new Exception("Descrição da compra é obrigatória");

            if (valorDevido <= 0)
                throw new Exception("Valor devido deve ser maior que zero");

            DataCompra = DateTime.Now;
            Descricao = descricao;
            ValorDevido = valorDevido;
            IdempotencyKey = idempotencyKey;
        }

        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime DataCompra { get; private set; }
        public string? Descricao { get; private set; }
        public decimal ValorDevido { get; private set; }
        public bool Pago { get; set; }
        public decimal? ValorPago { get; private set; }
        public DateTime? DataPagamento { get; private set; }
        public Guid IdempotencyKey { get; set; }
        public decimal Pagar(decimal valorPago)
        {
            if (valorPago <= 0)
                throw new Exception("Valor pago deve ser maior que zero");

            if (Pago)
                throw new Exception("Compra já foi paga");

            var troco = 0m;

            ValorDevido = ValorDevido - valorPago;
            ValorPago = valorPago;

            if (ValorDevido <= 0)
            {
                ValorDevido = 0m;
                DataPagamento = DateTime.Now;
                Pago = true;
            }
            else
            {
                Pago = false;
                DataPagamento = null;
            }

            return troco;
        }
    }
}
