using MediatR;
using TCE.Application.DTOs;

namespace TCE.Application.Commands.CompraCommands
{
    public class UpdateCompraCommand : IRequest<CompraDTO>
    {
        public Guid Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string? Descricao { get; set; }
        public decimal ValorCompra { get; set; }
        public bool Pago { get; set; }
        public decimal? ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
