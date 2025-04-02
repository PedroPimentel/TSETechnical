using MediatR;
using TCE.Application.DTOs;

namespace TCE.Application.Commands.ClienteCommands
{
    public class UpdateClienteCommand : IRequest<ClienteDTO>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
