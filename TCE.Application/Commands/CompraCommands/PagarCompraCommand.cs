using MediatR;
using TCE.Application.DTOs;

public class PagarCompraCommand : IRequest<MessageDTO<Guid>>
{
    public Guid Id { get; set; }
    public decimal ValorPago { get; set; }

    public PagarCompraCommand(Guid id, decimal valorPago)
    {
        Id = id;
        ValorPago = valorPago;
    }
}
