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

namespace TCE.Application.Queries
{
    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ClienteDTO>
    {
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public GetClienteByIdQueryHandler(IRepository<Cliente> clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            if (cliente == null) return null;

            // Mapeia a entidade Cliente para o ClienteDTO
            return _mapper.Map<ClienteDTO>(cliente);
        }
    }

}
