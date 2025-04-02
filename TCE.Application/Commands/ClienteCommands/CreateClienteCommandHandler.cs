using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;
using TCE.Infrastructure.Repository;

namespace TCE.Application.Commands.ClienteCommands
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Guid>
    {
        private readonly IRepository<Cliente> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateClienteCommandHandler(IRepository<Cliente> clienteRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = clienteRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Cliente>(request);
            await _repository.AddAsync(cliente);

            await _unitOfWork.SaveChangesAsync();

            return cliente.Id;
        }
    }
}
