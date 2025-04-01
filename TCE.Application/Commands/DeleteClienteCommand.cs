using MediatR;
using System;
namespace TCE.Application.Commands
{
    public class DeleteClienteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
