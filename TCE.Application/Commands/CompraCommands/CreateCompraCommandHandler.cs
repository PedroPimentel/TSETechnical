using AutoMapper;
using MediatR;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Commands.CompraCommands
{
    public class CreateCompraCommandHandler : IRequestHandler<CreateCompraCommand, Guid>
    {
        private readonly IRepository<Compra> _compraRepository;
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCompraCommandHandler(IRepository<Compra> compraRepository, IMapper mapper,
            IUnitOfWork unitOfWork, IRepository<Cliente> clienteRepository)
        {
            _compraRepository = compraRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCompraCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId);

            if (cliente == null) throw new Exception("Cliente não encontrado");
            
            var compra = _mapper.Map<Compra>(request);
            
            await _compraRepository.AddAsync(compra);
            await _unitOfWork.SaveChangesAsync();

            return compra.Id;
        }
    }
}
