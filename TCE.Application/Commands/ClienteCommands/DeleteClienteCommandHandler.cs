using MediatR;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Commands.ClienteCommands
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IRepository<Cliente> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClienteCommandHandler(IRepository<Cliente> repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id);

            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com Id {request.Id} não encontrado.");

            await _repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
