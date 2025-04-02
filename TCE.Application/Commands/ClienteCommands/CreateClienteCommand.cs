using MediatR;

namespace TCE.Application.Commands.ClienteCommands
{
    public class CreateClienteCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
