using MediatR;
using System;
namespace TCE.Application.Commands.CompraCommands
{
    public class DeleteCompraCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
