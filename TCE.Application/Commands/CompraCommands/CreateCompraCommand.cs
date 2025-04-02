using MediatR;

namespace TCE.Application.Commands.CompraCommands
{
    public class CreateCompraCommand : IRequest<Guid>
    {
        public Guid ClienteId { get; set; }
        public DateTime DataCompra { get; set; }
        public string? Descricao { get; set; }
        public decimal ValorDevido { get; set; }
        public bool Pago { get; set; }
        public decimal? ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }

        public Guid IdempotencyKey { get; set; }
    }
}
