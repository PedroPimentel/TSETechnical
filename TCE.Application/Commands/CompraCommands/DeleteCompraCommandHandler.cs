using MediatR;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Commands.CompraCommands
{
    public class DeleteCompraCommandHandler : IRequestHandler<DeleteCompraCommand>
    {
        private readonly IRepository<Compra> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompraCommandHandler(IRepository<Compra> repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCompraCommand request, CancellationToken cancellationToken)
        {
            var Compra = await _repository.GetByIdAsync(request.Id);

            if (Compra == null)
                throw new KeyNotFoundException($"Compra com Id {request.Id} não encontrado.");

            await _repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
