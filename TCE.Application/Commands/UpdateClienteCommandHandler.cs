using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Application.DTOs;
using TCE.Domain.Core.IRepository;
using TCE.Domain.Entities;

namespace TCE.Application.Commands
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ClienteDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _unitOfWork.GetRepository<Cliente>().GetByIdAsync(request.Id);
            
            _mapper.Map(request, cliente);

            await _unitOfWork.GetRepository<Cliente>().UpdateAsync(cliente);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ClienteDTO>(cliente);
        }
    }
}
